#!/bin/bash
sh ./deploy.sh &
exec geth --ipcdisable --rpc --rpcapi "eth,net,web3,miner" --rpcaddr=0.0.0.0 --rpcvhosts=* --rpccorsdomain=* --ws --wsorigins=* --wsaddr=0.0.0.0 --wsapi "eth,net,web3" --graphql --graphql.corsdomain=* --graphql.vhosts=* --datadir "/chaindata" --vm.evm=./lib/libevmone.so --mine --miner.threads=1 --miner.gastarget "0x8000000" --verbosity "4" --maxpeers=0 --syncmode=full