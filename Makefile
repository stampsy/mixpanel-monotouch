# Directories
NAME=Mixpanel
TARGET=$(NAME)
BINDDIR=.
PROJECT_ROOT=$(NAME)
PROJECT=$(PROJECT_ROOT)/$(NAME).xcodeproj

# Binaries
XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch


SRC=AssemblyInfo.cs \
	Bindings.cs \
	Extra.cs

all: $(NAME).dll

lib$(NAME)-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

lib$(NAME)-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

lib$(NAME)-Universal.a: lib$(NAME)-armv7.a lib$(NAME)-i386.a
	lipo -create -output $@ $^

$(NAME).dll: $(BINDDIR)/AssemblyInfo.cs $(BINDDIR)/ApiDefinition.cs $(BINDDIR)/Extra.cs lib$(NAME)-Universal.a
	$(BTOUCH) -unsafe --outdir=tmp -out:$@ $(BINDDIR)/ApiDefinition.cs -x=$(BINDDIR)/AssemblyInfo.cs -x=$(BINDDIR)/Extra.cs --link-with=lib$(NAME)-Universal.a,lib$(NAME)-Universal.a

clean:
	-rm -f *.a *.dll
	-rm -fr tmp $(PROJECT_ROOT)/build
	-rm -fr build
