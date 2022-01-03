namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class JumpToNewLocationSavingReturnAddress : InstructionWithWordOperand
    {
        internal JumpToNewLocationSavingReturnAddress(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Absolute, "JSR", 0x20, 3, 6)
        {
        }

        internal override void Execute()
        {
            var returnAddress = (ushort)(this.RomAddress + this.Bytes);
            this.Machine.PushValueOnStack(returnAddress);
            this.Machine.ProgramCounter = this.Operand;
        }
    }
}
