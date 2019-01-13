``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.2 (18C54) [Darwin 18.2.0]
Intel Core i9-8950HK CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|    Method |       Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------- |-----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| SystemXml | 9,175.3 ns | 179.97 ns | 351.02 ns |      2.4414 |      0.1373 |           - |            15.08 KB |
|   FastXml | 1,236.0 ns |  24.33 ns |  40.66 ns |      0.3242 |      0.0019 |           - |                2 KB |
|   NanoXml |   873.2 ns |  16.98 ns |  18.88 ns |      0.3033 |      0.0029 |           - |             1.87 KB |
