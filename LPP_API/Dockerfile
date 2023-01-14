FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR ./
COPY ./ ./

RUN dotnet build -o out

ENTRYPOINT ["dotnet", "./out/LPP.API.dll", "--urls=http://0.0.0.0:5000/"]

EXPOSE 5000
