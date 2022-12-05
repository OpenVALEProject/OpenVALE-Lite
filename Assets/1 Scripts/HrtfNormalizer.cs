using HDF.PInvoke;
using System.Runtime.InteropServices;
using UnityEngine;

public class HrtfNormalizer {
    public static void NormalizeHrtf(string filePath) {
        long fileId = -1, datasetId = -1;
        try {
            // Class abbreviations match what is described in docs at https://portal.hdfgroup.org/pages/viewpage.action?pageId=50073943
            // Based loosely on https://stackoverflow.com/questions/18068261/reading-hdf5-data-from-c-how-to-read-this-specific-format

            // H5F = H5 File operations
            // H5P = H5 Property Lists
            fileId = H5F.open(filePath, H5F.ACC_RDWR, H5P.DEFAULT);
            if (fileId < 0) {
                Debug.Log("Warning! File could not be opened.");
                return;
            }
            // H5D = H5 Dataset
            datasetId = H5D.open(fileId, "Data.IR");
            if (fileId < 0) {
                Debug.Log("Warning! Data.IR dataset not found.");
                return;
            }
            long spaceId = H5D.get_space(datasetId);
            long typeId = H5D.get_type(datasetId);
            // H5S = H5 data space
            // https://stackoverflow.com/a/15791325
            int rank = H5S.get_simple_extent_ndims(spaceId);
            var dimensionsOfRanks = new ulong[rank];
            H5S.get_simple_extent_dims(spaceId, dimensionsOfRanks, null);
            ulong dataLen = 1;
            foreach (var dim in dimensionsOfRanks) {
                dataLen *= dim;
            }
            var inData = new double[dataLen];
            var readHandle = GCHandle.Alloc(inData, GCHandleType.Pinned);
            int readCode = -1;
            try {
                readCode = H5D.read(datasetId, typeId, H5S.ALL, H5S.ALL, H5P.DEFAULT, readHandle.AddrOfPinnedObject());
            } finally {
                readHandle.Free();
            }

            if (readCode < 0) {
                Debug.Log("Warning! HRTF Normalizer encountered an error reading HRTF. Data may be flawed.");
            }

            // TODO: Determine data to write
            var outData = new double[0];
            return;

            var writeHandle = GCHandle.Alloc(outData, GCHandleType.Pinned);
            var writeCode = -1;
            try {
                writeCode = H5D.write(datasetId, typeId, H5S.ALL, H5S.ALL, H5P.DEFAULT, writeHandle.AddrOfPinnedObject());
            } finally {
                writeHandle.Free();
            }

            if (writeCode < 0) {
                Debug.Log("Warning! HRTF Normalizer encountered an error writing HRTF. Data may be flawed.");
            }
        } finally {
            H5D.close(datasetId);
            H5F.close(fileId);
        }

    }
}
