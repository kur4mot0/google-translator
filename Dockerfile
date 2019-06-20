FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY . .
RUN ls
RUN dotnet restore google-translator/google-translator.csproj
WORKDIR /src/google-translator
RUN dotnet build google-translator.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish google-translator.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "google-translator.dll"]
