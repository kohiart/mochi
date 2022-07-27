# Mochi

Mochi is essentially a Docker Image for a geth client that:

- uses evmone/evmc to replace the built-in EVM with a much faster version
- removes or drastically increases all timeouts and gas limitations of a typical geth client

## Why though?

Kohi's current development state needs Mochi for verifying that on-chain artworks we produce in Solidity/EVM will render. 

It can also be used to verify Kohi art pieces, though this is a work in progress.

## Verifying an artwork takes forever!

Yes, at the moment rendering times are anywhere from four hours to nine days, depending on the complexity of the metadata derived from the seed of a given artwork.

It won't always be this way.

The intention for Kohi as a platform is to render these EVM pieces with a GPU, resulting in near real-time performance, and the ability to use EVM to make 3D artworks, and artworks with interactivity (using time as a medium).

Right now, Mochi is required for our early works, but will phase out of existence when further tooling is shipped.

## Getting Started

- Install (Docker Desktop)[https://www.docker.com/products/docker-desktop]
- Run `run.bat` to deploy contracts to the Docker node
- Run `Kohi.exe`
