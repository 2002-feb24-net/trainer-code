# 1. docker build -f better.Dockerfile -t helloworldapp:3.0 .
# 2. docker run helloworldapp:3.0

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

COPY . ./

RUN dotnet publish -o publish

# starts a new "stage" - previous layers will not be incorporated into the final image
# you would only do this if you were planning to copy something from the previous stage
FROM mcr.microsoft.com/dotnet/core/runtime:3.1

WORKDIR /app

# by default, COPY pulls from the build context,
# but with --from, we can tell it to copy from a previous stage.

# take the /app/publish folder from the previous stage,
# put its contents in this stage's /app folder.
COPY --from=build /app/publish ./

CMD [ "dotnet", "HelloWorldApp.dll" ]

# using multi-stage build to get the advantages of repeatable builds in Docker
# without the disadvantages of a large SDK base image.
