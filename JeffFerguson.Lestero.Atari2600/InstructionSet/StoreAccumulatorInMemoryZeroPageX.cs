namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// STA
    /// </summary>
    /// <remarks>
    /// Flags:
    /// N Z C I D V
    /// - -	- -	- -
    /// </remarks>
    internal class StoreAccumulatorInMemoryZeroPageX : InstructionWithByteOperand
    {
        internal StoreAccumulatorInMemoryZeroPageX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPageX, "STA", 0x95, 2, 4)
        {
        }

        /// <summary>
        /// Executes the STA instruction.
        /// </summary>
        /// <remarks>
        /// Stores the contents of the Accumulator to zero page with address calculated from operand adding content of Index Register X
        /// </remarks>
        internal override void Execute()
        {
            var zeroPageOffset = this.Operand + this.Machine.RegisterX;
            this.Machine.ZeroPage[zeroPageOffset] = this.Machine.Accumulator;
        }
    }
}
