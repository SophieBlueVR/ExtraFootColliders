#!/usr/bin/bash
#
# Generate a meta file

OBJTYPE=$1
UUID=$2
if [ -z "$UUID" ]; then
    UUID=$(cat /proc/sys/kernel/random/uuid | sed 's/-//g')
fi

case $OBJTYPE in
    file)
        cat <<END
fileFormatVersion: 2
guid: ${UUID}
TextScriptImporter:
  externalObjects: {}
  userData: 
  assetBundleName: 
  assetBundleVariant: 
END
        ;;
    *)
        cat <<END
fileFormatVersion: 2
guid: ${UUID}
folderAsset: yes
DefaultImporter:
  externalObjects: {}
  userData:
  assetBundleName:
  assetBundleVariant:
END
        ;;
esac
