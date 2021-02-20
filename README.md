---
### Cotización Express
Sistema desarrollado para el vendedor de una tienda de ropa mayorista, para realizar cotizaciones de sus productos.

### Diagrama de clases
![Diagrama de Clases](https://raw.githubusercontent.com/noemimorales/CotizadorExpress/develop/Clases%20Cotizador%20Express.bmp)

---
#### 1. Nombre completo:

Noemí Morales.

#### 2. ¿C# permite herencia múltiple?

No, C# no permite herencia múltiple.

#### 3. ¿Cuándo utilizaría una Clase Abstracta en lugar de una Interfaz? Ejemplifique.

Abstracta:
- Una clase sólo puede heredar de otra clase (que puede ser clase abstracta).
- Una clase abstracta puede tener métodos que sean abstractos o no. 
- Una clase abstracta no se puede instanciar, provee estructura y comportamiento a las clases hijas.

Por ejemplo: 
Círculo, Cuadrado y Triángulo son clases hijas de la clase FiguraGeométrica y se aplica la generalización.

Interfaz:
- La interfaz sólo puede definir métodos abstractos.
- Una clase puede implementar todas las interfaces que quiera.
- La interfaz es como un contrato, todas las clases que se adhieran a ella van a poder implementar sus métodos.
- En la interfaz, se habla de un comportamiento que pueden tener en común clases que hereden de clases abstractas diferentes.

Por ejemplo:
El método volar lo puede realiza un pájaro (hijo de animal) y un avión (hijo de transporte). 


#### 4. ¿Qué implica una relación de Generalización entre dos clases?

Es una relación "es un tipo de". Hay una clase padre o superclase que es general, y una subclase o clase hija que es específica.

#### 5. ¿Qué implica una relación de Implementación entre una clase y una interfaz?

Implica que la clase va a realizar un comportamiento que está definido en la interfaz, y lo realizará de una manera propia. Quizás otra clase implemente el mismo método pero de una manera diferente.

Por ejemplo, un ave no vuela de la misma manera que un avión.

#### 6. ¿Qué diferencia hay entre la relación de Composición y la Agregación?

La relación de Composición es una relación más fuerte que la de Agregación, es decir, que si eliminamos una clase en la Agregación, la otra clase puede seguir existiendo, mientras que en la Composición al eliminar una clase, eliminamos la otra, ya que la relación entre ambas es estrecha. La composición se representa con un rombo negro, mientras que la agregación se representa con un rombo vacío.

#### 7. Indique V o F según corresponda. Diferencia entre Asociación y Agregación:

##### a. Una diferencia es que la segunda indica la relación entre un “todo” y sus “partes”, mientras que en la primera los objetos están al mismo nivel contextual.

**Verdadero**

##### b. Una diferencia es que la Agregación es de cardinalidad 1 a muchos mientras que la Asociación es de 1 a 1.

**Falso**

##### c. Una diferencia es que, en la Agregación, la vida o existencia de los objetos relacionados está fuertemente ligada, es decir que si “muere” el objeto contenedor también morirán las “partes”, en cambio en la Asociación los objetos viven y existen independientemente de la relación.

**Falso**

---
