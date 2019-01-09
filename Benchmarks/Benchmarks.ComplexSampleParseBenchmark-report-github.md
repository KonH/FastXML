``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.2 (18C54) [Darwin 18.2.0]
Intel Core i9-8950HK CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|    Method |       Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------- |-----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| SystemXml | 7,129.8 ns | 136.89 ns | 162.95 ns |      2.2278 |      0.0687 |           - |            13.72 KB |
|   FastXml | 2,427.9 ns |  48.09 ns |  77.65 ns |      0.4349 |      0.0038 |           - |             2.69 KB |
|   NanoXml |   575.0 ns |  11.37 ns |  17.02 ns |      0.2222 |      0.0010 |           - |             1.37 KB |
