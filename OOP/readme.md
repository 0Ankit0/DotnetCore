# The concepts that needs to be covered to master OOP.

## **📌 Basic Level (Fundamentals of OOP in C#)**  
🔹 **Goal:** Build a strong foundation in OOP principles and syntax.  

### **1️⃣ Classes and Objects**  
- Understanding classes, objects, and object instantiation.  
- Creating methods and calling them from objects.  

### **2️⃣ Encapsulation (Access Modifiers & Properties)**  
- Using `private`, `public`, `protected`, `internal`, and `protected internal`.  
- Implementing properties (`get`, `set`) with data validation.  

### **3️⃣ Constructors and Destructors**  
- Default, parameterized, and copy constructors.  
- Constructor overloading.  
- Destructor (`~ClassName`) and garbage collection.  

### **4️⃣ Inheritance (Code Reusability & Hierarchy)**  
- Creating base and derived classes.  
- Understanding **single inheritance** and **constructor chaining** using `base` keyword.  

### **5️⃣ Polymorphism**  
- **Method Overloading** (same method, different parameters).  
- **Method Overriding** (`virtual`, `override`, `sealed`).  
- Difference between **compile-time** and **runtime polymorphism**.  

### **6️⃣ Exception Handling and Custom Exceptions**  
- Using `try-catch-finally` blocks.  
- Throwing (`throw`) and catching (`catch`) exceptions.  
- Creating **custom exception classes**.  

---

## **📌 Intermediate Level (Advanced OOP Concepts & Object Relationships)**  
🔹 **Goal:** Learn more advanced object-oriented techniques and structures.  

### **1️⃣ Abstract Classes and Interfaces**  
- Abstract classes vs. interfaces.  
- Implementing multiple interfaces in a class.  

### **2️⃣ Properties, Indexers, and Auto-Implemented Properties**  
- Using **`get` and `set`** with private fields.  
- Implementing **indexers** for array-like behavior.  

### **3️⃣ Static Classes and Members**  
- Understanding **static methods, properties, and classes**.  
- Singleton vs. static classes.  

### **4️⃣ Composition vs. Aggregation**  
- **Composition (Strong Relationship, "has-a")**  
- **Aggregation (Weak Relationship, "has-a but can exist without it")**  
- Choosing between **inheritance vs. composition**.  

### **5️⃣ Operator Overloading**  
- Overloading `+`, `-`, `==`, `!=`, `++`, `--`, etc.  
- Implementing `Equals()` and `GetHashCode()`.  

### **6️ Explicit & Implicit Conversions**  
- Overloading `implicit` and `explicit` conversion operators.  
- Understanding `Type Casting` vs. `Type Conversion`.  

### **7️⃣ Records vs. Classes (C# 9+)**  
- Understanding **immutable data types** using `record`.  
- Value types vs. reference types.  

### **8️⃣ Custom Attributes and Reflection**  
- Defining and applying **custom attributes**.  
- Using `System.Reflection` to inspect metadata at runtime.  

### **9️⃣ Deconstruction**  
- using **Deconstructor** to get required data from an object.  
- Using **Deconstructor** with typles to receive the data.  
---

## **📌 Advanced Level (Professional OOP Techniques & Design Patterns)**  
🔹 **Goal:** Learn professional-level OOP techniques, best practices, and design patterns.  

### **1️⃣ Generics (Type-Safe Programming)**  
- Creating **generic classes and methods**.  
- Using **generic constraints** (`where T : class`).  

### **2️⃣ Delegates and Events**  
- Understanding **delegates** and function pointers.  
- Implementing **events** and event handlers.  
- Using **Action<T>, Func<T>, and Predicate<T>**.  

### **3️⃣ Lambda Expressions and LINQ**  
- Writing **lambda expressions** for concise function definitions.  
- Using **LINQ queries** for filtering and querying collections.  

### **4️⃣ Dependency Injection (DI) and SOLID Principles**  
- Implementing **constructor injection** for better decoupling.  
- Understanding **SOLID Principles**:  
  - **S**ingle Responsibility Principle (SRP).  
  - **O**pen/Closed Principle (OCP).  
  - **L**iskov Substitution Principle (LSP).  
  - **I**nterface Segregation Principle (ISP).  
  - **D**ependency Inversion Principle (DIP).  

### **5️⃣ Multiple Inheritance via Interfaces**  
- Using **multiple interfaces** in a class to simulate multiple inheritance.  
- Understanding **explicit interface implementation**.  

### **6️⃣ Mixing OOP with Functional Programming**  
- Using **LINQ** and **functional programming** techniques.  
- Using **Tuples** and **Pattern Matching** in C#.  

### **7️⃣ Memory Management & Garbage Collection**  
- Understanding **managed vs. unmanaged memory**.  
- Implementing `IDisposable` and using `using` statements.  

### **8️⃣ Thread Safety in OOP**  
- Implementing **thread-safe Singleton** pattern.  
- Using `lock`, `Monitor`, `volatile`, and `Interlocked`.  

### **9️⃣ Records**  
- Immutable reference types, record keyword, value-based equality  
---

## **📌 Design Patterns (Best Practices in OOP Architecture)**
🔹 **Goal:** Apply industry-standard design patterns in real-world applications.  

### **1️⃣ Singleton Pattern**  
- Ensuring **only one instance** of a class exists.  
- Making it **thread-safe**.  

### **2️⃣ Factory Pattern**  
- Encapsulating **object creation** to improve flexibility.  
- Avoiding tight coupling.  

### **3️⃣ Repository Pattern**  
- Abstracting database access logic.  
- Separating business logic from data access.  

### **4️⃣ Strategy Pattern**  
- Encapsulating **algorithms** and selecting them at runtime.  
- Reducing `if-else` statements in business logic.  

### **5️⃣ Observer Pattern**  
- Implementing **event-driven programming** using **observers**.  

---
