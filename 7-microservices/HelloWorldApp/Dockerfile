# to use this Dockerfile: (which requires you to build the app manually)
# 1. dotnet publish -o publish
# 2. docker build -t helloworldapp:1.0 .
# 3. docker run helloworldapp:1.0
# and then you can build the image,
# containers based on that image will have my app running.

# the Dockerfile is a set of instructions to build a new image from a base image plus
# a directory of files called the "build context" (typically the same directory
# the Dockerfile is in)

# things in the Dockerfile
# 1. what base image
#     - images are hosted in registries e.g. Docker Hub
#        (just like Git repos are hosted in places like GitHub)
# 2. commands to run in order to build the new image
# 3. metadata including what command to run to start the container

FROM mcr.microsoft.com/dotnet/core/runtime:3.1

# we have the base image and its initial files...
# now we need to move in our own files

# change the "current directory" for relative paths inside the image's file system
# (i.e. it's like "cd")
WORKDIR /app

# copies the publish folder from outside the image
# into the current directory on the image (/app)
COPY publish ./

# now... what command should be run LATER,
# to start a new container from this image?
CMD ["dotnet", "HelloWorldApp.dll"]

# if you install .net core sdk,
    # dotnet command knows about run, build, etc.
# if you only have the runtime installed,
    # it only knows how to run an assembly: "dotnet (my-assembly.dll)"
