FROM debian:stable as mochi

# install build dependencies
RUN apt-get update --fix-missing
RUN apt-get install -y sudo
RUN apt-get install -y wget
RUN apt-get install -y make
RUN apt-get install -y golang
RUN apt-get install -y curl
RUN apt-get install -y cmake

RUN mkdir -p /client
RUN chown root /client
WORKDIR /client

# install deployment stack
ENV NODE_VERSION=14.18.0
RUN curl -o- https://raw.githubusercontent.com/creationix/nvm/v0.34.0/install.sh | bash
ENV NVM_DIR=/root/.nvm
RUN . "$NVM_DIR/nvm.sh" && nvm install ${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm use v${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm alias default v${NODE_VERSION}
ENV PATH="/root/.nvm/versions/node/v${NODE_VERSION}/bin/:${PATH}"
RUN npm install -g npm@latest
RUN npm install --save-dev "hardhat" "mocha" "chai" "@nomiclabs/hardhat-waffle@^2.0.3" "@nomiclabs/hardhat-ethers@^2.0.0" "@nomiclabs/hardhat-waffle@^2.0.0" "ethers@^5.0.0" "ethereum-waffle@^3.2.0"

# upload contracts for deployment
ADD contracts /client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin/evmone/contracts
ADD test /client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin/evmone/test
COPY hardhat.config.js /client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin/evmone/hardhat.config.js
COPY .mocharc.json /client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin/evmone/.mocharc.json

# for initializing with our desired configuration
COPY genesis.json /client/genesis.json

# for unlocking the test account
COPY UTC--2021-09-19T06-12-01.985998519Z--5aa4c644554d07febafea3267a252bd1eebdd4a8 /chaindata/keystore/UTC--2021-09-19T06-12-01.985998519Z--5aa4c644554d07febafea3267a252bd1eebdd4a8

# The official binary has a hard-coded timeout of 5 seconds for `eth_call`, so we have to build a custom version
#RUN wget -c https://github.com/ewasm/go-ethereum/releases/download/v1.9.2-evmc.6.3.0-0/geth-linux-amd64-1.9.2-evmc.6.3.0.tar.gz -O - | tar -xz

COPY go-ethereum-1.9.2-evmc.6.3.0-0.tar.gz geth.tar.gz
RUN tar -xf geth.tar.gz
WORKDIR /client/go-ethereum-1.9.2-evmc.6.3.0-0
RUN make geth

WORKDIR /client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin

# evmone is a fast EVM implementation we want to plug in to geth
# RUN wget -c https://github.com/ethereum/evmone/releases/download/v0.2.0/evmone-0.2.0-linux-x86_64.tar.gz -O - | tar -xz
COPY evmone-0.2.0 /client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin/evmone
WORKDIR /client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin/evmone
RUN cmake -S . -B build -DEVMONE_TESTING=OFF
RUN cmake --build build --parallel

ENV PATH="/client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin:/client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin/evmone:${PATH}"

# initialize the geth node with our config data
RUN geth init /client/genesis.json --datadir "/chaindata"
COPY entrypoint.sh /client/go-ethereum-1.9.2-evmc.6.3.0-0/build/bin/entrypoint.sh

EXPOSE 8545 8546 30303 30303/udp 30304/udp
STOPSIGNAL SIGINT
ENTRYPOINT ["entrypoint.sh"]