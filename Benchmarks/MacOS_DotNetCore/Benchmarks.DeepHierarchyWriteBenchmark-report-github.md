``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.2 (18C54) [Darwin 18.2.0]
Intel Core i9-8950HK CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|    Method |     Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------- |---------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| SystemXml | 5.640 us | 0.1113 us | 0.2274 us |      0.9689 |           - |           - |                6 KB |
|   FastXml | 2.032 us | 0.0404 us | 0.0807 us |      0.5646 |      0.0038 |           - |             3.48 KB |
