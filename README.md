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