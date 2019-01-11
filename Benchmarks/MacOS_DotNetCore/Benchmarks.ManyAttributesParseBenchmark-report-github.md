``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.2 (18C54) [Darwin 18.2.0]
Intel Core i9-8950HK CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|    Method |       Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------- |-----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| SystemXml | 9,333.1 ns | 174.94 ns | 155.08 ns |      2.4414 |      0.1373 |           - |            15.08 KB |
|   FastXml | 1,429.5 ns |  21.87 ns |  20.46 ns |      0.3300 |      0.0038 |           - |             2.04 KB |
|   NanoXml |   925.1 ns |  18.05 ns |  16.00 ns |      0.3033 |      0.0029 |           - |             1.87 KB |
