Sophie's Extra Foot Colliders
=============================

In VRChat, you can only interact with other players' Physbones with your hands.

But have you ever wanted to poke your friend's toes with yours?  Or to kick
someone's tail?  Well now you can!

This package allows you to move two of the default colliders from your fingers
(which you probably don't use anyway) to your feet.

[![Generic badge](https://img.shields.io/badge/Unity-2022.3.6f1-informational.svg)](https://unity.com/releases/editor/whats-new/2022.3.6)
[![Generic badge](https://img.shields.io/badge/SDK-AvatarSDK3-informational.svg)](https://vrchat.com/home/download)

## Usage

On your avatar's root object, in the inspector window underneath the avatar
descriptor, click the `Add Component` button and choose `Extra Foot Colliders`
from the list which appears (you may have to search for it).

By default, the ring finger on each hand will be moved to become your new foot
collider on the same side.  You can also choose to use the middle finger bones
instead.

Also by default, the new foot colliders will be the same size and location as the
default ones provided by the SDK (you know, the ones which don't interact with
physbones).  Changes made to those will also be made to these moved finger
colliders.

If you prefer, you can instead override the size and position of each collider
specifically by checking the appropriate checkbox and setting values.  Note that
similar to the default colliders, a height setting of `0` will result in a
spherical collider, using a value greater than zero makes the collider capsule
shaped.

That's it, now just build and publish your avatar normally.

### NOTE

If you have Physbones on your toes (i.e. "physbeans" or "phystoes") already,
an altered foot collider will interact with the physbones on the same foot
constantly, and probably in an undesirable way.

To prevent this, in the Physbone component for your toes, change `Allow
Collision` from `True` to `Other`, and *deselect* `Allow Self`.


## Installation

There are several methods, pick **only one**:

### VCC

Go to my [VPM Repository](https://sophiebluevr.github.io/vpm/) and simply click
`Add to VCC`!

### VPM

You can also use [VRChat's VPM tool](https://vcc.docs.vrchat.com/vpm/cli/)!
First add my [VPM Repository](https://sophiebluevr.github.io/vpm/index.json)

```
vpm add repo https://sophiebluevr.github.io/vpm/index.json
```

Then you can simply go to your project directory and type:

```
vpm add package io.github.sophiebluevr.extrafootcolliders
```

### UnityPackage

While using VCC or VPM is the preferred method, you can also download the
unitypackage from the **releases** section in this repository (on the right over
there --> ) and then install the unitypackage the usual way, from the menu bar
in Unity, going to `Assets` then `Import Package` then `Custom Package...` and
selecting the file.

## License

Sophie's Extra Foot Colliders © 2024 by SophieBlue is licensed under
Attribution-NonCommercial-ShareAlike 4.0 International 

To view a copy of this license, visit
http://creativecommons.org/licenses/by-nc-sa/4.0/
