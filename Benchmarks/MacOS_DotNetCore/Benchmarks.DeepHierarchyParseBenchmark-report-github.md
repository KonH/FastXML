``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.2 (18C54) [Darwin 18.2.0]
Intel Core i9-8950HK CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|    Method |     Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------- |---------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| SystemXml | 8.401 us | 0.1669 us | 0.3410 us |      2.4567 |      0.1068 |           - |            15.19 KB |
|   FastXml | 1.694 us | 0.0333 us | 0.0499 us |      0.4692 |      0.0076 |           - |             2.88 KB |
|   NanoXml | 1.141 us | 0.0228 us | 0.0435 us |      0.4730 |      0.0076 |           - |             2.91 KB |
