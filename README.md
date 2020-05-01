# builderCSharp
Example using Builder Design Pattern 


When it comes to building highly scalable systems, choosing and using the right creational pattern for our objects is considered a crucial step where the builder pattern comes as one of the solutions.The Gang of Four states that builder pattern goal is “to separate the construction of complex object from its representation so that the same construction process can create different representations”. In other words, the creation of objects is done in an abstract way through an interface, where concrete classes implement the interface blueprint, however the concrete don’t instantiate themselves, this is done through the use of the director class, which handles the actual object creation.

Builder pattern is not always applicable, its use applies to situations when dealing with complex objects, when the object creation should be independent from its assembly, and when the construction must allow different object representations that perform similar functions.    


Builder pattern has four main components:
Builder: This is an interface containing steps for object creation and since this will be applied to the creation of different representations, the names used should be general so they can be applied to all cases.   
Concrete Builder: This class will implement all abstract methods defined in the builder interface and it’s in charge of construction and assembly of any object composition. Also, it’s responsible for tracking the object it creates.  
Director: Defines the necessary steps to build the product.
Product: Represents the complex object under construction.
