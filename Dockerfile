FROM microsoft/dotnet:runtime
ENV ASPNETCORE_URLS http://+:5000
WORKDIR /app
COPY ./WallboardBack/out ./
ENTRYPOINT ["dotnet", "WallboardBack.dll"]