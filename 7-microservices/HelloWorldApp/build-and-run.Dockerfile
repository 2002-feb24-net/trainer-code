# for tomorrow:
# make a dockerfile here that doesn't require a dotnet publish beforehand.
# 1. docker build -f build-and-run.Dockerfile -t helloworldapp:2.0 .
# 2. docker run helloworldapp:2.0

# (use -f to specify the dockerfile's location. the default is,
# [build-context]/Dockerfile.)

FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app

COPY . ./

RUN dotnet publish -o publish

RUN rm -rf .net sdk

CMD ["dotnet", "publish/HelloWorldApp.dll"]

# with this dockerfile, we get the advantages of docker's isolation
# in both build-time and runtime.

# but there are still some issues/bad practices to address....
