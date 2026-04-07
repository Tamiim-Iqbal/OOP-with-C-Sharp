#### What is Abstraction?

Answer:
**Abstraction** means hiding the complex internal details and showing only the necessary features of an object. It helps you focus on what an object does instead of how it does it.

In C\#, abstraction is achieved using:

- Abstract classes
- Interfaces

**✅ Real-Life Example:**
When you drive a car, you just use the steering wheel, brake, and accelerator — you don’t need to know how the engine works internally. That’s abstraction.

**Code Example: Using Abstract Class**

```csharp
public abstract class Course
{
    public string title;

    // Abstract method - no body here
    public abstract void ShowDetails();
}

public class CompetitiveProgrammingCourse : Course
{
    // Must override the abstract method
    public override void ShowDetails()
    {
        Console.WriteLine("This is a Competitive Programming course.");
    }
}
```

**Usage:**

```csharp
Course c = new CompetitiveProgrammingCourse();
c.title = "CP Bootcamp";
c.ShowDetails();
```

**✅ In short (Interview style):**
"Abstraction means showing only the important information and hiding unnecessary details. We use abstract classes or interfaces to define what should be done, and the derived class defines how it should be done."

#### What is an Abstract Class?

Answer:
An abstract class is a class that cannot be instantiated directly. It may contain both:

- **Abstract methods** (methods without a body that must be overridden in derived classes)
- **Non-abstract methods** (methods with a body, shared among all child classes)

We use abstract classes when we want to define a common structure for all subclasses, but leave the specific implementation to the subclasses.

**✅ Real-Life Example: Payment System**
Let’s say we are building a payment system. All payment types have an amount and transaction ID, and all must process the payment and verify the details — but the process is different for each type (Credit Card or Bkash).

**Code Example:**

```csharp
// Abstract base class
public abstract class CoursePayment
{
    public double amount;
    public string transactionId;

    // Abstract methods – must be implemented in child classes
    public abstract void ProcessPayment();
    public abstract void VerifyDetails();

    // Common method
    public void ShowInfo()
    {
        Console.WriteLine($"Amount: {amount}, Transaction ID: {transactionId}");
    }
}

// Derived Class 1: Credit Card Payment
public class CreditCardPayment : CoursePayment
{
    public string creditCardNumber;

    public override void ProcessPayment()
    {
        Console.WriteLine("Processing payment through Credit Card...");
    }

    public override void VerifyDetails()
    {
        Console.WriteLine($"Verifying credit card number: {creditCardNumber}");
    }
}

// Derived Class 2: Bkash Payment
public class BkashPayment : CoursePayment
{
    public string bkashNumber;

    public override void ProcessPayment()
    {
        Console.WriteLine("Processing payment through Bkash...");
    }

    public override void VerifyDetails()
    {
        Console.WriteLine($"Verifying Bkash number: {bkashNumber}");
    }
}
```

**✅ Usage:**

```csharp
CreditCardPayment ccPayment = new CreditCardPayment();
ccPayment.amount = 5000;
ccPayment.transactionId = "TXN123";
ccPayment.creditCardNumber = "1234-5678-9999-0000";
ccPayment.ShowInfo();
ccPayment.ProcessPayment();
ccPayment.VerifyDetails();

Console.WriteLine();

BkashPayment bkash = new BkashPayment();
bkash.amount = 3500;
bkash.transactionId = "BK123";
bkash.bkashNumber = "017xxxxxxxx";
bkash.ShowInfo();
bkash.ProcessPayment();
bkash.VerifyDetails();
```

**Output:**

```
Amount: 5000, Transaction ID: TXN123
Processing payment through Credit Card...
Verifying credit card number: 1234-5678-9999-0000

Amount: 3500, Transaction ID: BK123
Processing payment through Bkash...
Verifying Bkash number: 017xxxxxxxx
```

**✅ In Short (Interview Style):**
"An abstract class defines a common structure but lets child classes define the specific behavior. In this example, `CoursePayment` defines that all payment types must have `ProcessPayment()` and `VerifyDetails()`, but how they do it depends on the class — Credit Card and Bkash have different ways."

#### What is an Interface?

Answer:
An interface is like a contract that defines what a class must do, but not how it does it.

- It only contains method signatures (no implementation).
- A class that implements the interface must provide the implementation for all its methods.
- Interfaces support multiple inheritance (a class can implement multiple interfaces).

Interfaces are used when you want to define common behavior across unrelated classes.

**✅ Real-Life Example (Payment System)**
All payment methods (Credit Card, Bkash, etc.) must have `ProcessPayment()` and `VerifyDetails()`, but they work differently.
Instead of using a base class, we define an interface:

**Code Example:**

```csharp
// Define interface
public interface IPayment
{
    void ProcessPayment();
    void VerifyDetails();
}

// Class 1: CreditCardPayment implements IPayment
public class CreditCardPayment : IPayment
{
    public string creditCardNumber;

    public void ProcessPayment()
    {
        Console.WriteLine("Processing payment using Credit Card...");
    }

    public void VerifyDetails()
    {
        Console.WriteLine($"Verifying Credit Card: {creditCardNumber}");
    }
}

// Class 2: BkashPayment implements IPayment
public class BkashPayment : IPayment
{
    public string bkashNumber;

    public void ProcessPayment()
    {
        Console.WriteLine("Processing payment using Bkash...");
    }

    public void VerifyDetails()
    {
        Console.WriteLine($"Verifying Bkash Number: {bkashNumber}");
    }
}
```

**Usage:**

```csharp
IPayment payment1 = new CreditCardPayment { creditCardNumber = "1234-5678-9012-3456" };
payment1.ProcessPayment();
payment1.VerifyDetails();

Console.WriteLine();

IPayment payment2 = new BkashPayment { bkashNumber = "017xxxxxxxx" };
payment2.ProcessPayment();
payment2.VerifyDetails();
```

**✅ Output:**

```
Processing payment using Credit Card...
Verifying Credit Card: 1234-5678-9012-3456

Processing payment using Bkash...
Verifying Bkash Number: 017xxxxxxxx
```

**✅ In Short (Interview Style):**
"An interface defines what methods a class should have, but not how they work. It's like a rulebook. The classes that implement the interface must provide their own implementation. It helps create flexible and decoupled code."

#### What is the Difference between an Abstract class and an Interface?

Answer:
An **abstract class** is like a partially complete class. It can have both implemented methods and abstract methods. That means it can have some code already written that child classes can use. I use an abstract class when I want to share common behavior among related classes and also force them to implement specific methods.

On the other hand, an **interface** is like a full contract — it only has method names, no implementation. When a class implements an interface, it must write code for all the methods. I use interfaces when I just want to define a set of rules that different classes, even if they’re not related, have to follow.

One main difference is that I can only inherit from one abstract class, but I can implement multiple interfaces.

So, if I need shared code with some flexibility, I go for abstract class. If I just need structure or multiple abilities like logging, saving, etc., I use interfaces.