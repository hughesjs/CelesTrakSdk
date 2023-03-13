# CelesTrakSdk

[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/hughesjs/CelestrakSdk/dotnet-ci.yml?label=BUILD%20CI&style=for-the-badge&branch=master)](https://github.com/hughesjs/CelestrakSdk/actions)
[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/hughesjs/CelestrakSdk/dotnet-cd.yml?label=BUILD%20CD&style=for-the-badge&branch=master)](https://github.com/hughesjs/CelestrakSdk/actions)
![GitHub top language](https://img.shields.io/github/languages/top/hughesjs/CelestrakSdk?style=for-the-badge)
[![GitHub](https://img.shields.io/github/license/hughesjs/CelestrakSdk?style=for-the-badge)](LICENSE)
![FTB](https://raw.githubusercontent.com/hughesjs/custom-badges/master/made-in/made-in-scotland.svg)

## Introduction

This is a C# SDK for working with the [CelesTrak APIs](https://celestrak.org). These APIs are largely modified versions of the Space Track APIs that are slightly easier to work with and have some QoL improvements.

Currently, only the SATCAT Records API is implemented, this may be expanded on in the future.

## Getting Started

There are two packages `CelesTrakSdk` and `CelesTrakSdk.Microsoft.Extensions.DependencyInjection`, you'll want to install both using NuGet.

Register the services with your DI provider using:

```cs
services.AddCelesTrakServices();
```

This API has no authentication, so that's all there is to it.

You should then be able to inject `ICelesTrakClient` into any of your services.

## Getting Data

There are currently three methods on the client interface:

```cs
public interface ICelesTrakClient
{
	public Task<SatCatRecord?>      GetRecord(SatCatRecordQueryType  queryType, string queryValue);
	public Task<List<SatCatRecord>> GetRecords(SatCatRecordQueryType queryType, string queryValue);
	public Task<List<SatCatRecord>> GetAllRecords();
}
```

You can get a single record, get a group of records, or get all records.

Queries are very simple, consisting of a type and a value. The following types are available, these are defined by CelesTrak:

- CatalogNumber
- InternationalDesignator
- Group
- Name
- Special

It's worth noting, this SDK currently does no validation of query values. Furthermore, if a query passed to `.GetRecord()` returns multiple values, only the first will be returned.

