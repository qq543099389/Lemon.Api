#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 62653
EXPOSE 44316

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Lemon.API/Lemon.API.csproj", "Lemon.API/"]
RUN dotnet restore "Lemon.API/Lemon.API.csproj"
COPY . .
WORKDIR "/src/Lemon.API"
RUN dotnet build "Lemon.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Lemon.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Lemon.API.dll"]