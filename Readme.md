# How to prevent removing a master record referenced by other records


<p>This example demonstrates how to implement your classes, to save the referential integrity of your tables when removing master objects being referenced by other objects. This solution is appropriate when you have the Deferred Deletion feature of XPO turned off. Without the code in this example, you will get an SQLException. This solution will allow you to provide your users with more meaningful exceptions, when such a situation takes place.</p><p>The Master object in this example has an aggregated One-To-Many relationship to Child objects. If a Master object has some aggregated children, it can be immediately deleted with all associated Child objects. However, if there is a Neighbour object, having a reference (without association) to this Master object, the code will raise an exception, notifying about existing referencing objects.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/S91931">Core - Introduce an automatic check to the deleting algorithm whether an object is referenced by any other object</a><br />
<a href="https://www.devexpress.com/Support/Center/p/Q100872">Deferred deletion and (foreign key) exception handling</a></p>

<br/>


