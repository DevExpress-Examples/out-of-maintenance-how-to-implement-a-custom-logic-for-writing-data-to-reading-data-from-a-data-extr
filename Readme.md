<!-- default file list -->
*Files to look at*:

* [ExtractEncryptionDriver.cs](./CS/Dashboard_CustomExtractDriver/ExtractEncryptionDriver.cs) (VB: [ExtractEncryptionDriver.vb](./VB/Dashboard_CustomExtractDriver/ExtractEncryptionDriver.vb))
* [Form1.cs](./CS/Dashboard_CustomExtractDriver/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_CustomExtractDriver/Form1.vb))
<!-- default file list end -->
# How to Encrypt/Decrypt Data Transfer Between the Data Extract File and a Dashboard

This example demonstrates how to create a custom driver to encrypt/decrypt extract data. 

![screenshot](/images/screenshot.png)


A custom driver is an object that implements the <a href="https://documentation.devexpress.com/#Dashboard/clsDevExpressDashboardCommonICustomExtractDrivertopic">ICustomExtractDriver</a> interface as follows: 
* The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonICustomExtractDriver_CreateWriteSessiontopic">ICustomExtractDriver.CreateWriteSession</a> method creates a write session to encrypt extract pages.
* The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonICustomExtractDriver_CreateReadSessiontopic">ICustomExtractDriver.CreateReadSession</a> method creates a read session that provides logic for reading encrypted pages.

See also:

* [Extract Data Source](https://docs.devexpress.com/Dashboard/115900/)