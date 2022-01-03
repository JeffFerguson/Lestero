namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class FreezeCpu : Instruction
    {
        internal FreezeCpu(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "JAM", 0x42, 1, 1)
        {
        }
    }
}
