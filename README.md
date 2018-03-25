# Gdo

Gradient Descent Optimization algorithms for .NET Core

1. Adagrad
2. Adam
3. Adadelta
4. RMSprop

## Installing

```
PM> Install-Package Gdo.koryakinp
```

## Example
compute a deriviative `dx` and provide it to optimizer:
```
var opt1 = new Adagrad(0.1);
var res1 = opt1.Compute(dx);
```
`Adagrad` optimizer will use 0.1 learning rate to update the value.
Similiarly you can use defferent optimizers:
#### Adam
```
var opt2 = new Adam(100, 1000, 0.01);
var res2 = opt2.Compute(dx);
```
#### RMSprop
```
var opt3 =  new RMSprop(0.1, 20);
var res3 = opt3.Compute(dx);
```
#### Adadelta
```
var opt4 = new Adadelta(25, 0.1);
var res4 = opt4.Compute(dx);
```
## Authors

Pavel koryakin <koryakinp@koryakinp.com>

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/koryakinp/gdo/blob/master/LICENSE) for details.

## Acknowledgments

- [Sebastian Ruder, An overview of gradient descent optimization algorithms](http://ruder.io/optimizing-gradient-descent/index.html)
