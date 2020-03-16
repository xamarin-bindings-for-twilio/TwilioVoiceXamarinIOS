#!/usr/bin/env bash

carthage bootstrap
sharpie bind -o bindings -namespace=Twilio.Voice.iOS -sdk iphoneos13.2 -framework Carthage/Build/iOS/TwilioVoice.framework
