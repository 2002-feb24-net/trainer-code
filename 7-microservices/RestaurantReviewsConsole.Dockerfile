# 1. docker build -f RestaurantReviewsConsole.Dockerfile -t rest-reviews:2.1 ../2-sql/RestaurantReviewsv2.1
# 2. docker run --rm -it rest-reviews:2.1

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

COPY . ./

RUN dotnet publish RestaurantReviews.ConsoleUI -o publish

FROM mcr.microsoft.com/dotnet/core/runtime:3.1

WORKDIR /app

COPY --from=build /app/publish ./

CMD [ "dotnet", "RestaurantReviews.ConsoleUI.dll" ]
