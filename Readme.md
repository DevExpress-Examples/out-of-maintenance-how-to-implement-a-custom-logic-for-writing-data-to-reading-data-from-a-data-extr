<!-- default file list -->
*Files to look at*:

* [ExtractEncryptionDriver.cs](./CS/Dashboard_CustomExtractDriver/ExtractEncryptionDriver.cs) (VB: [ExtractEncryptionDriver.vb](./VB/Dashboard_CustomExtractDriver/ExtractEncryptionDriver.vb))
* [Form1.cs](./CS/Dashboard_CustomExtractDriver/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_CustomExtractDriver/Form1.vb))
<!-- default file list end -->
# How to implement a custom logic for writing data to/reading data from a data extract


This example demonstrates how to create a custom driver that will be used to encrypt/decrypt extract data by implementing the <a href="https://documentation.devexpress.com/#Dashboard/clsDevExpressDashboardCommonICustomExtractDrivertopic">ICustomExtractDriver</a> interface. The following methods are implemented for this interface.<br>- The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonICustomExtractDriver_CreateWriteSessiontopic">ICustomExtractDriver.CreateWriteSession</a> method creates a write session that is used to encrypt extract pages.<br>- The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonICustomExtractDriver_CreateReadSessiontopic">ICustomExtractDriver.CreateReadSession</a> method creates a read session that provides logic for reading encrypted pages.

<br/>


