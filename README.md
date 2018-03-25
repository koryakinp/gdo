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
compute a deriviative `dx` and provide it to `Update()` method of the optimizer:
```
var opt1 = new Adagrad(0.1);
opt1.SetValue(10);
opt1.Update(dx);
var res1 = opt1.Value;
```
`Adagrad` optimizer will use 0.1 learning rate to update the value.
Similarly you can use different optimizers:
#### Adam
```
var opt2 = new Adam(0.01, 100, 1000);
opt2.SetValue(10);
opt2.Update(dx);
var res2 = opt2.Value;
```
#### RMSprop
```
var opt3 =  new RMSprop(0.1, 25);
opt3.SetValue(10);
opt3.Update(dx);
var res3 = opt3.Value;
```
#### Adadelta
```
var opt4 = new Adadelta(0.1, 25);
opt4.SetValue(10);
opt4.Update(dx);
var res4 = opt4.Value;
```
## Authors

Pavel koryakin <koryakinp@koryakinp.com>

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/koryakinp/gdo/blob/master/LICENSE) for details.

## Acknowledgments

- [Sebastian Ruder, An overview of gradient descent optimization algorithms](http://ruder.io/optimizing-gradient-descent/index.html)
