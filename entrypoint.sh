#!/bin/bash
deploy_scripts() {
    npx hardhat test
    geth --exec "miner.stop()" attach http://localhost:8545
}
deploy_scripts &
exec geth --rpc --rpcapi "eth,net,web3" --rpcaddr=0.0.0.0 --rpcvhosts=* --rpccorsdomain=* --ws --wsorigins=* --wsaddr=0.0.0.0 --wsapi "eth,net,web3" --graphql --graphql.corsdomain=* --graphql.vhosts=* --datadir "/chaindata" --vm.evm=./build/lib/libevmone.so --mine --miner.threads=1 --miner.gastarget "0x800000000000" --verbosity "4" --nousb --maxpeers=0 --syncmode=full
