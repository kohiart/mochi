// See: https://hardhat.org/plugins/nomiclabs-hardhat-ethers.html#library-linking
// See: https://hardhat.org/guides/waffle-testing.html

const { expect } = require("chai");

describe("Kintsugi", function () {
  it("should deploy", async function () {

    const [deployer] = await ethers.getSigners();
    console.log("Deploying contracts with the account:", deployer.address);
    console.log("Account balance:", (await deployer.getBalance()).toString());

    //
    // Kohi
    const Kohi = await ethers.getContractFactory("Kohi");
    if (await ethers.provider.getCode("0x7b62D26EfB24E95334D52dEe696F79D89bb7411F") !== "0x") {
      console.log("Kohi already deployed.");
    }
    else {
      const KohiDeploy = await Kohi.deploy();
      await KohiDeploy.deployed();
      expect(await ethers.provider.getCode(KohiDeploy.address)).to.not.equal("0x");
      console.log("Kohi deployed to: " + KohiDeploy.address);
      console.log("Kohi length: " + KohiDeploy.deployTransaction.data.length);
    }
    //

    //
    // SinLut256
    const SinLut256 = await ethers.getContractFactory("SinLut256");
    if (await ethers.provider.getCode("0x7C7F6F925307398e01c923F52FE4889a4d054D0D") !== "0x") {
      console.log("SinLut256 already deployed.");
    } else {
      const SinLut256Deploy = await SinLut256.deploy();
      await SinLut256Deploy.deployed();
      expect(await ethers.provider.getCode(SinLut256Deploy.address)).to.not.equal("0x");
      console.log("SinLut256 deployed to: " + SinLut256Deploy.address);
      console.log("SinLut256 length: " + SinLut256Deploy.deployTransaction.data.length);
    }
    //   

    // 
    // NoiseV1    
    const NoiseV1 = await ethers.getContractFactory("NoiseV1", {
      libraries: {
        SinLut256: "0x7C7F6F925307398e01c923F52FE4889a4d054D0D"
      },
    });
    if (await ethers.provider.getCode("0x3Fb5877CAD6Dbe10805124017c702cBB3a8BcFb1") !== "0x") {
      console.log("NoiseV1 already deployed.");
    } else {
      const NoiseV1Deploy = await NoiseV1.deploy();
      await NoiseV1Deploy.deployed();
      expect(await ethers.provider.getCode(NoiseV1Deploy.address)).to.not.equal("0x");
      console.log("NoiseV1 deployed to: " + NoiseV1Deploy.address);
      console.log("NoiseV1 length: " + NoiseV1Deploy.deployTransaction.data.length);
    }
    //

    //
    // ParticleSetFactoryV1
    const ParticleSetFactoryV1 = await ethers.getContractFactory("ParticleSetFactoryV1");
    if (await ethers.provider.getCode("0x274c28Af41942D79d35D20A78600Cac06059aA42") !== "0x") {
      console.log("ParticleSetFactoryV1 already deployed.");
    } else {
      const ParticleSetFactoryV1Deploy = await ParticleSetFactoryV1.deploy();
      await ParticleSetFactoryV1Deploy.deployed();
      expect(await ethers.provider.getCode(ParticleSetFactoryV1Deploy.address)).to.not.equal("0x");
      console.log("ParticleSetFactoryV1 deployed to: " + ParticleSetFactoryV1Deploy.address);
      console.log("ParticleSetFactoryV1 length: " + ParticleSetFactoryV1Deploy.deployTransaction.data.length);
    }
    //

    /////////////////// GENERIC ^^^^^^ //////////////////////

    //
    // HatchLayer
    const HatchLayer = await ethers.getContractFactory("HatchLayer");
    if (await ethers.provider.getCode("0xf8e694389354bF12899B3b9e7380f9611B2b7063") !== "0x") {
      console.log("HatchLayer already deployed.");
    } else {
      const HatchLayerDeploy = await HatchLayer.deploy();
      await HatchLayerDeploy.deployed();
      expect(await ethers.provider.getCode(HatchLayerDeploy.address)).to.not.equal("0x");
      console.log("HatchLayer deployed to: " + HatchLayerDeploy.address);
      console.log("HatchLayer length: " + HatchLayerDeploy.deployTransaction.data.length);
    }
    //

    // 
    // HatchDraw
    const HatchDraw = await ethers.getContractFactory("HatchDraw");
    if (await ethers.provider.getCode("0x0607373b0dD741697770A4Cc1D41580f4f7751Be") !== "0x") {
      console.log("HatchDraw already deployed.");
    } else {
      const HatchDrawDeploy = await HatchDraw.deploy();
      await HatchDrawDeploy.deployed();
      expect(await ethers.provider.getCode(HatchDrawDeploy.address)).to.not.equal("0x");
      console.log("HatchDraw deployed to: " + HatchDrawDeploy.address);
      console.log("HatchDraw length: " + HatchDrawDeploy.deployTransaction.data.length);
    }
    //

    //
    // WatercolorLayer
    const WatercolorLayer = await ethers.getContractFactory("WatercolorLayer", {
      libraries: {
        SinLut256: "0x7C7F6F925307398e01c923F52FE4889a4d054D0D"
      },
    });
    if (await ethers.provider.getCode("0xDba6D8Bc1B5Af35B17912e1A06b1983FA2Bc3ea9") !== "0x") {
      console.log("WatercolorLayer already deployed.");
    } else {
      const WatercolorLayerDeploy = await WatercolorLayer.deploy();
      await WatercolorLayerDeploy.deployed();
      expect(await ethers.provider.getCode(WatercolorLayerDeploy.address)).to.not.equal("0x");
      console.log("WatercolorLayer deployed to: " + WatercolorLayerDeploy.address);
      console.log("WatercolorLayer length: " + WatercolorLayerDeploy.deployTransaction.data.length);
    }
    //

    //
    // WatercolorDraw
    const WatercolorDraw = await ethers.getContractFactory("WatercolorDraw");
    if (await ethers.provider.getCode("0x3776cD7bf3e78d90868f397b7e3F37186f7667a2") !== "0x") {
      console.log("WatercolorDraw already deployed.");
    } else {
      const WatercolorDrawDeploy = await WatercolorDraw.deploy();
      await WatercolorDrawDeploy.deployed();
      expect(await ethers.provider.getCode(WatercolorDrawDeploy.address)).to.not.equal("0x");
      console.log("WatercolorDraw deployed to: " + WatercolorDrawDeploy.address);
      console.log("WatercolorDraw length: " + WatercolorDrawDeploy.deployTransaction.data.length);
    }
    //    

    // 
    // KintsugiLayer
    const KintsugiLayer = await ethers.getContractFactory("KintsugiLayer", {
      libraries: {
        ParticleSetFactoryV1: "0x274c28Af41942D79d35D20A78600Cac06059aA42"
      },
    });
    if (await ethers.provider.getCode("0x2DE63946308007D08Ee46Eb1d990302d1f6fdb05") !== "0x") {
      console.log("KintsugiLayer already deployed.");
    } else {
      const KintsugiLayerDeploy = await KintsugiLayer.deploy();
      await KintsugiLayerDeploy.deployed();
      expect(await ethers.provider.getCode(KintsugiLayerDeploy.address)).to.not.equal("0x");
      console.log("KintsugiLayer deployed to: " + KintsugiLayerDeploy.address);
      console.log("KintsugiLayer length: " + KintsugiLayerDeploy.deployTransaction.data.length);
    }
    //

    // 
    // KintsugiDraw
    const KintsugiDraw = await ethers.getContractFactory("KintsugiDraw", {
      libraries: {
        NoiseV1: "0x3Fb5877CAD6Dbe10805124017c702cBB3a8BcFb1",
        SinLut256: "0x7C7F6F925307398e01c923F52FE4889a4d054D0D"
      },
    });
    if (await ethers.provider.getCode("0xEeDD5a691b632c603d500013F4B34C9119416F99") !== "0x") {
      console.log("KintsugiDraw already deployed.");
    } else {
      const KintsugiDrawDeploy = await KintsugiDraw.deploy();
      await KintsugiDrawDeploy.deployed();
      expect(await ethers.provider.getCode(KintsugiDrawDeploy.address)).to.not.equal("0x");
      console.log("KintsugiDraw deployed to: " + KintsugiDrawDeploy.address);
      console.log("KintsugiDraw length: " + KintsugiDrawDeploy.deployTransaction.data.length);
    }
    //

    //
    // Kintsugi (rendering contract):
    const Kintsugi = await ethers.getContractFactory("Kintsugi", {
      libraries: {
        HatchLayer: "0xf8e694389354bF12899B3b9e7380f9611B2b7063",
        HatchDraw: "0x0607373b0dD741697770A4Cc1D41580f4f7751Be",
        WatercolorLayer: "0xDba6D8Bc1B5Af35B17912e1A06b1983FA2Bc3ea9",
        WatercolorDraw: "0x3776cD7bf3e78d90868f397b7e3F37186f7667a2",
        KintsugiLayer: "0x2DE63946308007D08Ee46Eb1d990302d1f6fdb05",
        KintsugiDraw: "0xEeDD5a691b632c603d500013F4B34C9119416F99",
        NoiseV1: "0x3Fb5877CAD6Dbe10805124017c702cBB3a8BcFb1",
      },
    });
    if (await ethers.provider.getCode("0xA9a6506b20b234B015B6f6183EFf26fcBAf8f349") !== "0x") {
      console.log("Kintsugi already deployed.");
    } else {
      const KintsugiDeploy = await Kintsugi.deploy("0x7b62D26EfB24E95334D52dEe696F79D89bb7411F");
      await KintsugiDeploy.deployed();
      expect(await ethers.provider.getCode(KintsugiDeploy.address)).to.not.equal("0x");
      console.log("Kintsugi deployed to: " + KintsugiDeploy.address);
      console.log("Kintsugi length: " + KintsugiDeploy.deployTransaction.data.length);
    }
  });
});