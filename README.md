# String Compression Toolkit

A .NET project implementing multiple compression algorithms (Huffman, RLE) with a factory pattern for easy extension.

## Features

- **Algorithms**:
  - Huffman Coding (optimal prefix coding)
  - Run-Length Encoding (RLE)
  - Extensible interface for new algorithms

- **Core Components**:
  - Compressor factory pattern
  - Generic `ICompressor` interface
  - Round-trip compression/decompression

