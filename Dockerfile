FROM microsoft/dotnet:sdk
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./WallboardBack/*.csproj ./
RUN dotnet restore

# copy everything else and build
COPY ./WallboardBack ./
RUN dotnet publish -c Release -o out

# this is temporary, production should use the runtime image
ENTRYPOINT ["dotnet", "out/WallboardBack.dll"]

# build runtime image
# FROM microsoft/dotnet:runtime
# WORKDIR /app
# COPY --from=0 /app/out ./
# ENTRYPOINT ["dotnet", "WallboardBack.dll"]