namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class StoreAccumulatorInMemoryZeroPage : InstructionWithByteOperand
    {
        internal StoreAccumulatorInMemoryZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "STA", 0x85, 2, 4)
        {
        }

        /// <summary>
        /// Executes the STA instruction.
        /// </summary>
        /// <remarks>
        /// Stores the contents of the Accumulator to zero page with address calculated from operand.
        /// </remarks>
        internal override void Execute()
        {
            var zeroPageOffset = this.Operand;
            this.Machine.ZeroPage[zeroPageOffset] = this.Machine.Accumulator;
        }
    }
}
