﻿/*
    Copyright (C) 2014-2017 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace dnSpy.AsmEditor.Compiler.MDEditor {
	sealed class StringsHeapWriter : MDHeapWriter {
		public override string Name => stringsHeap.Name;

		readonly StringsMDHeap stringsHeap;

		public StringsHeapWriter(StringsMDHeap stringsHeap) => this.stringsHeap = stringsHeap;

		public override void Write(MDWriter mdWriter, MDWriterStream stream, byte[] tempBuffer) {
			int start = (int)stringsHeap.StringsStream.StartOffset;
			int size = (int)(stringsHeap.StringsStream.EndOffset - stringsHeap.StringsStream.StartOffset);
			stream.Write(mdWriter.ModuleData, start, size);
			WriteData(stream, stringsHeap.NewData, tempBuffer);
		}
	}
}
