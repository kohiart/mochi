using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Kohi.Kintsugi.ContractDefinition;

namespace Kohi.Kintsugi
{
    public partial class KintsugiService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, KintsugiDeployment kintsugiDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<KintsugiDeployment>().SendRequestAndWaitForReceiptAsync(kintsugiDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, KintsugiDeployment kintsugiDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<KintsugiDeployment>().SendRequestAsync(kintsugiDeployment);
        }

        public static async Task<KintsugiService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, KintsugiDeployment kintsugiDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, kintsugiDeployment, cancellationTokenSource);
            return new KintsugiService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public KintsugiService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ChangeExecutorRequestAsync(ChangeExecutorFunction changeExecutorFunction)
        {
             return ContractHandler.SendRequestAsync(changeExecutorFunction);
        }

        public Task<TransactionReceipt> ChangeExecutorRequestAndWaitForReceiptAsync(ChangeExecutorFunction changeExecutorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeExecutorFunction, cancellationToken);
        }

        public Task<string> ChangeExecutorRequestAsync(string newExecutor)
        {
            var changeExecutorFunction = new ChangeExecutorFunction();
                changeExecutorFunction.NewExecutor = newExecutor;
            
             return ContractHandler.SendRequestAsync(changeExecutorFunction);
        }

        public Task<TransactionReceipt> ChangeExecutorRequestAndWaitForReceiptAsync(string newExecutor, CancellationTokenSource cancellationToken = null)
        {
            var changeExecutorFunction = new ChangeExecutorFunction();
                changeExecutorFunction.NewExecutor = newExecutor;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeExecutorFunction, cancellationToken);
        }

        public Task<string> GetAttributesQueryAsync(GetAttributesFunction getAttributesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAttributesFunction, string>(getAttributesFunction, blockParameter);
        }

        
        public Task<string> GetAttributesQueryAsync(int seed, BlockParameter blockParameter = null)
        {
            var getAttributesFunction = new GetAttributesFunction();
                getAttributesFunction.Seed = seed;
            
            return ContractHandler.QueryAsync<GetAttributesFunction, string>(getAttributesFunction, blockParameter);
        }

        public Task<RenderOutputDTO> RenderQueryAsync(RenderFunction renderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<RenderFunction, RenderOutputDTO>(renderFunction, blockParameter);
        }

        public Task<RenderOutputDTO> RenderQueryAsync(RenderArgs args, BlockParameter blockParameter = null)
        {
            var renderFunction = new RenderFunction();
                renderFunction.Args = args;
            
            return ContractHandler.QueryDeserializingToObjectAsync<RenderFunction, RenderOutputDTO>(renderFunction, blockParameter);
        }
    }
}
