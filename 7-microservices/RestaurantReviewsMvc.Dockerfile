# 1. docker build -f RestaurantReviewsMvc.Dockerfile -t rest-reviews:3.0 ../../nick-project1
# 2. docker run --rm -it -p 8000:80 -e "ConnectionStrings__RestaurantReviewsDb=(connection string)" rest-reviews:3.0

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

COPY . ./

RUN dotnet publish RestaurantReviews.WebUI -o publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=build /app/publish ./

CMD [ "dotnet", "RestaurantReviews.WebUI.dll" ]
