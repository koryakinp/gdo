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
var result = opt1.Compute(dx);
```
## Authors

Pavel koryakin <koryakinp@koryakinp.com>

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/koryakinp/gdo/blob/master/LICENSE) for details.

## Acknowledgments

- [Sebastian Ruder, An overview of gradient descent optimization algorithms](http://ruder.io/optimizing-gradient-descent/index.html)
