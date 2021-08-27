<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128592303/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1274)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Child.cs](./CS/WinWebSolution.Module/Child.cs) (VB: [Child.vb](./VB/WinWebSolution.Module/Child.vb))
* [Master.cs](./CS/WinWebSolution.Module/Master.cs) (VB: [Master.vb](./VB/WinWebSolution.Module/Master.vb))
* [Neighbour.cs](./CS/WinWebSolution.Module/Neighbour.cs) (VB: [Neighbour.vb](./VB/WinWebSolution.Module/Neighbour.vb))
<!-- default file list end -->
# OBSOLETE - How to prevent removing a master record referenced by other records

<p><strong>This solution is obsolete. The best way to validate data in an XAF application is to use the <a href="https://documentation.devexpress.com/eXpressAppFramework/113009/Concepts/Extra-Modules/Validation/Validation-Module">Validation Module</a>. Refer to the <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Validation.RuleIsReferencedAttribute.class">RuleIsReferencedAttribute</a>  article for a recommended solution.</strong><br><br


<p>This example demonstrates how to implement your classes, to save the referential integrity of your tables when removing master objects being referenced by other objects. This solution is appropriate when you have the Deferred Deletion feature of XPO turned off. Without the code in this example, you will get an SQLException. This solution will allow you to provide your users with more meaningful exceptions, when such a situation takes place.</p><p>The Master object in this example has an aggregated One-To-Many relationship to Child objects. If a Master object has some aggregated children, it can be immediately deleted with all associated Child objects. However, if there is a Neighbour object, having a reference (without association) to this Master object, the code will raise an exception, notifying about existing referencing objects.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/S91931">Core - Introduce an automatic check to the deleting algorithm whether an object is referenced by any other object</a><br />
<a href="https://www.devexpress.com/Support/Center/p/Q100872">Deferred deletion and (foreign key) exception handling</a></p>

<br/>


