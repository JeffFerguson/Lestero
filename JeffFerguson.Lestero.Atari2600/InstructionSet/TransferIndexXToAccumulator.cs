namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// TXA
    /// </summary>
    /// <remarks>
    /// Flags:
    /// N Z C I D V
    /// + +	- -	- -
    /// </remarks>
    internal class TransferIndexXToAccumulator : Instruction
    {
        internal TransferIndexXToAccumulator(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "TXA", 0x8A, 1, 2)
        {
        }

        internal override void Execute()
        {
            ManageNegativeFlag(this.Machine.Accumulator, this.Machine.RegisterX);
            this.Machine.Accumulator = this.Machine.RegisterX;
            ManageZeroFlag(this.Machine.Accumulator);
        }
    }
}
