FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
WORKDIR /Application
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /Application
COPY --from=builder /Application/output .

ENTRYPOINT [ "dotnet", "base_asp.dll" ]