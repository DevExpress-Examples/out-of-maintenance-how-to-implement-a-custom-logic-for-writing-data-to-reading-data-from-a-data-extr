![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581151/19.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T437252)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)

# How to Encrypt/Decrypt Data Transfer Between the Data Extract File and a Dashboard

This example demonstrates how to create a custom driver to encrypt/decrypt extract data. 

![screenshot](/images/screenshot.png)

A custom driver is an object that implements the <a href="https://documentation.devexpress.com/#Dashboard/clsDevExpressDashboardCommonICustomExtractDrivertopic">ICustomExtractDriver</a> interface as follows: 
* The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonICustomExtractDriver_CreateWriteSessiontopic">ICustomExtractDriver.CreateWriteSession</a> method creates a write session to encrypt extract pages.
* The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonICustomExtractDriver_CreateReadSessiontopic">ICustomExtractDriver.CreateReadSession</a> method creates a read session that provides logic for reading encrypted pages.

## Files to Look At:

* [ExtractEncryptionDriver.cs](./CS/Dashboard_CustomExtractDriver/ExtractEncryptionDriver.cs) (VB: [ExtractEncryptionDriver.vb](./VB/Dashboard_CustomExtractDriver/ExtractEncryptionDriver.vb))
* [Form1.cs](./CS/Dashboard_CustomExtractDriver/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_CustomExtractDriver/Form1.vb))

## Documentation

- [Extract Data Source](https://docs.devexpress.com/Dashboard/115900/)
- [Security Considerations](https://docs.devexpress.com/Dashboard/113775)
