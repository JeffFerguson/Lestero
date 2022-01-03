namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// DEX
    /// </summary>
    /// <remarks>
    /// Flags:
    /// N Z C I D V
    /// + +	- -	- -
    /// </remarks>
    internal class DecrementIndexXByOne : Instruction
    {
        internal DecrementIndexXByOne(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "DEX", 0xCA, 1, 2)
        {
        }

        internal override void Execute()
        {
            ManageNegativeFlag(this.Machine.RegisterX, (byte)(this.Machine.RegisterX - 1));
            this.Machine.RegisterX--;
            ManageZeroFlag(this.Machine.RegisterX);
        }
    }
}
