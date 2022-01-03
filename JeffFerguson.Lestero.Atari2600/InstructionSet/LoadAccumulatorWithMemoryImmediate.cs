namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// The function of LDA operator is to load a byte of memory into the accumulator and setting
    /// the zero and negative flags as appropriate.
    /// </summary>
    /// <remarks>
    /// Flags
    /// N Z C I D V
    /// + +	- -	- -
    /// </remarks>
    internal class LoadAccumulatorWithMemoryImmediate : InstructionWithByteOperand
    {
        internal LoadAccumulatorWithMemoryImmediate(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Immediate, "LDA", 0xA9, 2, 2)
        {
        }

        internal override void Execute()
        {
            this.ManageNegativeFlag(this.Machine.Accumulator, this.Operand);
            this.Machine.Accumulator = this.Operand;
            this.ManageZeroFlag(this.Operand);
        }
    }
}
