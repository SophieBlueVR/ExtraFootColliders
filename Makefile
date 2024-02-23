VERSION = $(shell awk '/^v[0-9]/ {print substr($$1, 2); exit }' CHANGELOG.md)
TARGET = ExtraFootColliders-v$(VERSION).unitypackage

all: build

version:
	@echo $(VERSION)

Editor/Version.cs: CHANGELOG.md
	@sed -i 's/VERSION = ".*"/VERSION = "v$(VERSION)"/' $@

package.json: .package.json.tmpl CHANGELOG.md
	env VERSION=$(VERSION) envsubst < $< > $@

$(TARGET): Editor/Version.cs package.json
	# copy stuff to a tempdir to build our release tree
	mkdir -p .tmp/Assets/SophieBlue/ExtraFootColliders
	ls | grep -v "Assets" | xargs -i{} cp -a {} .tmp/Assets/SophieBlue/ExtraFootColliders/
	.github/workflows/generate_meta.sh folder bc846a2331c27846b961e0f9fe107d54 > .tmp/Assets/SophieBlue.meta
	.github/workflows/generate_meta.sh folder 1b944c236943dca1481e192637dc56b4 > .tmp/Assets/SophieBlue/ExtraFootColliders.meta

	# build the unity package
	cup -c 2 -o $@ -s .tmp
	mv .tmp/$@ .
	rm -rf .tmp

	# rebuild the unity package
	unzip -d .tmp $@
	rm $@
	cd .tmp && tar cvf ../$@ * && cd -
	rm -rf .tmp

build: $(TARGET)

clean:
	rm -f $(TARGET)
	rm -rf .tmp
.PHONY: clean
