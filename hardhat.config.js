/**
 * @type import('hardhat/config').HardhatUserConfig
 */

// See: https://hardhat.org/config/
// See: https://docs.soliditylang.org/en/v0.7.4/using-the-compiler.html#input-description
// See: https://hardhat.org/guides/compile-contracts.html

require("@nomiclabs/hardhat-waffle");

module.exports = {
  defaultNetwork: "mochi",
  networks: {
    mochi: {
      chainId: 8134646,
      url: "http://127.0.0.1:8545",
      accounts: ["0xb0a587bc9681a7333763f84c3b90a4d58bd01b5fb0635ac16187f6f55e792a57"],
      gasPrice: "auto",
      gas: 100_000_000,
      timeout: 43200000
    }
  },
  solidity: {
    version: "0.8.7",
    settings: {
      optimizer: {
        enabled: true,
        runs: 1
      }
    }
  },
  mocha: {
    timeout: 2000000000
  }
};
