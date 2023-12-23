# Principios SOLID en C# curso
## SOLID
### S - responsabilidad Unica
Separar el código una clase se encargue de gestionar los datos de el modelo student y la otra en exportarlos en archivo csv
1 - obtener, insertar, actualizar y eliminar datos
2 - exportarlos en un archivo CSV
El file StudentRepository.cs se encarga de devolver datos, insertar, eliminar
Pero tiene el metodo de exportar a un file.csv
no debe exportar datos ya que este archivo debe ser solo para manipular datos
Vamos a separarlo, vamos a crear una clase par solo exportar el archivo 

### Definición de generics
La refactorización utilizando "generics" en C# se refiere a la práctica de reorganizar o mejorar el código existente mediante la introducción de tipos genéricos para hacer que el código sea más flexible, reutilizable y seguro. Los tipos genéricos permiten escribir código que puede funcionar con diferentes tipos de datos sin tener que crear múltiplas versiones del mismo código para cada tipo específico.

En C#, los "generics" se implementan mediante el uso de parámetros de tipo genérico en clases, estructuras, métodos e interfaces. Un ejemplo común de refactorización utilizando "generics" es convertir un código que utiliza tipos específicos en un código más genérico. Aquí hay un ejemplo sencillo:

Supongamos que tienes una clase que almacena una lista de números enteros:

```csharp
public class IntList
{
    private List<int> list = new List<int>();

    public void Add(int value)
    {
        list.Add(value);
    }

    public int Get(int index)
    {
        return list[index];
    }
}
```

Si deseas refactorizar este código utilizando "generics" para hacerlo más genérico y reutilizable, puedes crear una versión genérica de la clase utilizando un tipo de parámetro:

```csharp
public class GenericList<T>
{
    private List<T> list = new List<T>();

    public void Add(T value)
    {
        list.Add(value);
    }

    public T Get(int index)
    {
        return list[index];
    }
}
```

Con esta refactorización, ahora puedes utilizar la clase `GenericList` con cualquier tipo de datos, en lugar de estar limitado a números enteros. Por ejemplo, puedes usarlo con cadenas, objetos personalizados u otros tipos de datos.

La refactorización utilizando "generics" en C# se trata de escribir código más genérico y flexible, lo que a menudo conduce a un mejor mantenimiento y reutilización del código, así como a la reducción de errores al permitir la verificación de tipos en tiempo de compilación.


*********************************************************************************************************************************
---------------------------------------------------------------------------------------------------------------------------------

### Explicación de los Principios SOLID

Los principios SOLID son un conjunto de cinco principios de diseño de software que promueven la creación de código más mantenible, escalable y robusto. Aquí tienes un resumen y un ejemplo de cada uno de los principios aplicados en C#:

### Principio de Responsabilidad Única (SRP - Single Responsibility Principle)
**Resumen:** Este principio establece que una clase debe tener una sola razón para cambiar, es decir, debe tener una única responsabilidad.

**Ejemplo en C#:**
```csharp
// Mal - La clase maneja la lógica de impresión y la gestión de datos
public class Report
{
    public void GenerateReport()
    {
        // lógica para generar el reporte
    }

    public void SaveToFile()
    {
        // lógica para guardar el reporte en un archivo
    }
}

// Bien - La clase se enfoca en la generación del reporte solamente
public class Report
{
    public void GenerateReport()
    {
        // lógica para generar el reporte
    }
}

// Otra clase para manejar la persistencia del reporte
public class ReportSaver
{
    public void SaveToFile()
    {
        // lógica para guardar el reporte en un archivo
    }
}
```

### Principio de Abierto/Cerrado (OCP - Open/Closed Principle)
**Resumen:** Las entidades del software (clases, módulos, funciones, etc.) deben estar abiertas para la extensión pero cerradas para la modificación.

**Ejemplo en C#:**
```csharp
// Mal - Modificación directa de la clase existente para agregar nuevas formas de envío
public class Order
{
    public void ProcessOrder()
    {
        // lógica para procesar el pedido
    }
    
    public void ShipOrder(string shippingType)
    {
        if (shippingType == "standard")
        {
            // lógica para envío estándar
        }
        else if (shippingType == "express")
        {
            // lógica para envío express
        }
        // Más lógica para otros tipos de envío...
    }
}

// Bien - Utilización de interfaces y patrones para extender funcionalidades sin modificar la clase existente
public interface IShippingService
{
    void ShipOrder();
}

public class StandardShippingService : IShippingService
{
    public void ShipOrder()
    {
        // lógica para envío estándar
    }
}

public class ExpressShippingService : IShippingService
{
    public void ShipOrder()
    {
        // lógica para envío express
    }
}

public class Order
{
    private readonly IShippingService _shippingService;

    public Order(IShippingService shippingService)
    {
        _shippingService = shippingService;
    }

    public void ProcessOrder()
    {
        // lógica para procesar el pedido
    }

    public void ShipOrder()
    {
        _shippingService.ShipOrder();
    }
}
```

### Principio de Sustitución de Liskov (LSP - Liskov Substitution Principle)
**Resumen:** Este principio establece que los objetos de una clase derivada deben poder sustituirse por objetos de la clase base sin alterar el comportamiento del programa.

**Ejemplo en C#:**
```csharp
// Mal - Violación del principio de sustitución
public class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }

    public virtual void SetWidth(int width)
    {
        Width = width;
    }

    public virtual void SetHeight(int height)
    {
        Height = height;
    }

    public int CalculateArea()
    {
        return Width * Height;
    }
}

public class Square : Rectangle
{
    public override void SetWidth(int width)
    {
        Width = width;
        Height = width;
    }

    public override void SetHeight(int height)
    {
        Height = height;
        Width = height;
    }
}
```

En este caso, el principio no se cumple correctamente, ya que un `Square` no se comporta adecuadamente como un `Rectangle`. 

### Principio de Segregación de la Interfaz (ISP - Interface Segregation Principle)
**Resumen:** Este principio indica que los clientes no deben verse obligados a depender de interfaces que no utilizan. Es preferible tener interfaces específicas para cada cliente.

**Ejemplo en C#:**
```csharp
// Mal - Una interfaz demasiado grande
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

public class Robot : IWorker
{
    public void Work()
    {
        // lógica del robot trabajando
    }

    public void Eat()
    {
        // los robots no comen, esta implementación está vacía
    }

    public void Sleep()
    {
        // los robots no duermen, esta implementación está vacía
    }
}

// Bien - Interfaces segregadas
public interface IWorker
{
    void Work();
}

public interface IEater
{
    void Eat();
}

public interface ISleeper
{
    void Sleep();
}

public class Robot : IWorker
{
    public void Work()
    {
        // lógica del robot trabajando
    }
}

// Otra clase puede implementar solo lo que necesita
public class Human : IWorker, IEater, ISleeper
{
    public void Work()
    {
        // lógica del humano trabajando
    }

    public void Eat()
    {
        // lógica del humano comiendo
    }

    public void Sleep()
    {
        // lógica del humano durmiendo
    }
}
```

### Principio de Inversión de Dependencia (DIP - Dependency Inversion Principle)
**Resumen:** Este principio sugiere que los módulos de alto nivel no deben depender de módulos de bajo nivel, ambos deben depender de abstracciones. Además, las abstracciones no deben depender de los detalles, sino que los detalles deben depender de las abstracciones.

**Ejemplo en C#:**
```csharp
// Mal - Dependencia directa de una implementación concreta
public class LightSwitch
{
    private Bulb _bulb;

    public LightSwitch()
    {
        _bulb = new Bulb();
    }

    public void Toggle()
    {
        _bulb.Toggle();
    }
}

public class Bulb
{
    public void Toggle()
    {
        // lógica para encender/apagar la bombilla
    }
}

// Bien - Dependencia invertida utilizando una abstracción
public interface ISwitchable
{
    void Toggle();
}

public class LightSwitch
{
    private ISwitchable _device;

    public LightSwitch(ISwitchable device)
    {
        _device = device;
    }

    public void Toggle()
    {
        _device.Toggle();
    }
}

public class Bulb : ISwitchable
{
    public void Toggle()
    {
        // lógica para encender/apagar la bombilla
    }
}
```

Estos ejemplos ilustran cómo aplicar los principios de Sustitución de Liskov, Segregación de la Interfaz e Inversión de Dependencia en C# para escribir un código más flexible, mantenible y con una mejor organización de las responsabilidades.