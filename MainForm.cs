using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
namespace HideInBMP {
    public partial class MainForm : Form {

        private long BMPFileSize;
        private long hideFileSize;
        private long maxHideFileSize;
        private int width;
        private int height;
        private int bitsPerPixel;
        private bool fromSelected;
        private bool hideSelected;
        private byte[]? fileHeader;
        private byte[]? dibHeader;
        private byte[]? pixelData;
        private const int HEADER_SIZE = 4 + 8 + 8; // 长度头 + 校验码 + 后缀名
        private static readonly byte[] MAGIC_BYTES = Encoding.ASCII.GetBytes("SDSC0623");
        private Image? fromBMPPreview;
        private Image? outputBMPPreview;
        private ToolTip fromSizeTip = new();
        private ToolTip hideSizeTip = new();
        private ToolTip maxHideTip = new();
        public MainForm() {
            InitializeComponent();
        }

        private void fromBrowser_Click(object sender, EventArgs e) {
            DialogResult result = fromFile.ShowDialog();
            if (result.Equals(DialogResult.OK)) {
                SelectedFromBMP();
            }
        }
        private void fromPath_TextChanged(object sender, EventArgs e) {
            if (fromPath.Text == String.Empty) {
                fromSelected = false;
            } else {
                fromSelected = true;
            }
            CheckSizeAndChangeButton(hideOrExtractPath.Text);
        }

        private void hideOrExtractPath_TextChanged(object sender, EventArgs e) {
            if (hideOrExtractPath.Text == String.Empty) {
                hideSelected = false;
            } else {
                hideSelected = true;
            }
            CheckCheckButton();
        }

        private void SelectedFromBMP() {
            String filePath = fromFile.FileName;
            fromBMPPreview = Image.FromFile(filePath);
            fromBMP.Image = fromBMPPreview;
            BMPFileSize = getFileSize(filePath);
            fromSize.Text = getByteString(BMPFileSize);
            fileOperate(filePath);
            maxHideFileSize = (long)((double)(width * height * (bitsPerPixel / 8)) / 8) - HEADER_SIZE;
            maxHideSize.Text = getByteString(maxHideFileSize);
            fromPath.Text = filePath;
        }

        private String getByteString(long fileSize) {
            String result;
            if (fileSize > 1024 * 1024) {
                result = Math.Round(((double)fileSize) / (1024 * 1024), 2) + "MB";
            } else if (fileSize > 1024) {
                result = Math.Round(((double)fileSize) / 1024, 2) + "KB";
            } else {
                result = fileSize + "B";
            }
            return result;
        }

        private void outputBrowser_Click(object sender, EventArgs e) {
            DialogResult result = outputFile.ShowDialog();
            if (result.Equals(DialogResult.OK)) {
                outputPath.Text = outputFile.SelectedPath + "\\";
                CheckSizeAndChangeButton(hideOrExtractPath.Text);
                CheckExtractButton();
            }
        }
        private void hideBrowser_Click(object sender, EventArgs e) {
            DialogResult result = hideFile.ShowDialog();
            if (result.Equals(DialogResult.OK)) {
                String filePath = hideFile.FileName;
                hideOrExtractPath.Text = filePath;
                hideSize.Text = getByteString(hideFileSize = getFileSize(filePath));
                CheckSizeAndChangeButton(hideOrExtractPath.Text);
                CheckExtractButton();
            }
        }

        private void check_Click(object sender, EventArgs e) {
            // 验证校验码
            try {
                if (!ValidatePacket(ExtractFromPixels(File.ReadAllBytes(hideOrExtractPath.Text)))) {
                    MessageBox.Show("校验码错误，可能不是有效隐写文件");
                } else {
                    MessageBox.Show("校验码正确，此文件为有效隐写文件");
                }
            } catch (Exception ex) {
                MessageBox.Show("读取文件失败: " + ex.Message);
            }
        }

        private void CheckCheckButton() {
            if (hideOrExtractPath.Text == String.Empty) {
                check.Enabled = false;
            } else {
                check.Enabled = true;
            }
        }

        private void CheckExtractButton() {
            if (outputFile.SelectedPath == String.Empty || hideOrExtractPath.Text == String.Empty
                || Path.GetExtension(hideOrExtractPath.Text) != ".bmp") {
                startExtract.Enabled = false;
            } else {
                startExtract.Enabled = true;
            }
        }

        private void CheckSizeAndChangeButton(string filePath) {
            if (hideSelected && getFileSize(filePath) > maxHideFileSize && fromSelected) {
                startHide.Enabled = false;
                MessageBox.Show("隐写文件大小超过最大可隐写字节\n请重新选择 隐写目标图片 或 隐写文件");
            } else if (fromPath.Text == String.Empty || outputFile.SelectedPath == String.Empty || hideOrExtractPath.Text == String.Empty) {
                startHide.Enabled = false;
            } else {
                startHide.Enabled = true;
            }
        }

        private long getFileSize(String filePath) {
            try {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                    long fileSize = fs.Length;
                    return fileSize;
                }
            } catch (Exception ex) {
                MessageBox.Show("加载图片失败: " + ex.Message);
                return 0;
            }
        }

        private void reset_Click(object sender, EventArgs e) {
            Program.Restart();
        }

        private void exit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void about_Click(object sender, EventArgs e) {
            MessageBox.Show("把文件隐写进BMP图片\n原理限制，隐藏文件大小不能超过图片总像素数的 3/8 - 20\n即最大字节数为 width * height * 3 ÷ 8 - 20 = " + maxHideFileSize + "B", "BMP隐写文件 —— By SDSC0623");
        }


        private void fromSize_MouseHover(object sender, EventArgs e) {
            fromSizeTip = new ToolTip();
            fromSizeTip.Show("具体字节数为：" + BMPFileSize + " B", fromSize, 0, 38, 3000);
        }

        private void fromSize_MouseLeave(object sender, EventArgs e) {
            fromSizeTip.Dispose();
        }
        private void hideSize_MouseHover(object sender, EventArgs e) {
            hideSizeTip = new ToolTip();
            hideSizeTip.Show("具体字节数为：" + hideFileSize + " B", hideSize, 0, 38, 3000);
        }

        private void hideSize_MouseLeave(object sender, EventArgs e) {
            hideSizeTip.Dispose();
        }

        private void maxHideSize_MouseHover(object sender, EventArgs e) {
            maxHideTip = new ToolTip();
            maxHideTip.Show("具体字节数为：" + maxHideFileSize + " B", maxHideSize, 0, 38, 3000);
        }

        private void maxHideSize_MouseLeave(object sender, EventArgs e) {
            maxHideTip.Dispose();
        }

        private void fileOperate(String filePath) {
            try {
                // 读取BMP文件的字节
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                    using (BinaryReader br = new BinaryReader(fs)) {
                        // 读取BMP文件头 (14字节)
                        fileHeader = br.ReadBytes(14);

                        // 读取DIB头 (40字节) - 这个大小可能不同，对于BMP v3可能是12字节
                        dibHeader = br.ReadBytes(40);

                        // 解析文件头和DIB头以获取宽度和高度
                        width = (int)(dibHeader[4] | dibHeader[5] << 8 | dibHeader[6] << 16 | dibHeader[7] << 24);
                        height = (int)(dibHeader[8] | dibHeader[9] << 8 | dibHeader[10] << 16 | dibHeader[11] << 24);
                        bitsPerPixel = (int)(dibHeader[14] | dibHeader[15] << 8);
                        //Text = $"宽度: {width}, 高度: {height}, 每像素位数: {bitsPerPixel}";
                        //Console.WriteLine($"宽度: {width}, 高度: {height}, 每像素位数: {bitsPerPixel}");

                        // 计算像素数据的起始位置
                        int pixelDataOffset = fileHeader.Length + dibHeader.Length;

                        // 确定每行像素的字节数（考虑到行填充）
                        int rowSize = (width * bitsPerPixel + 31) / 32 * 4;

                        // 读取像素数据
                        fs.Seek(pixelDataOffset, SeekOrigin.Begin);
                        pixelData = br.ReadBytes(rowSize * height);

                        // 在这里可以修改 pixelData 数组来操作像素
                        // 例如，将第一个像素的第一个字节设置为0（通常代表红色分量的修改）
                        // pixelData[0] = 0;

                        // 如果需要保存修改后的图像，可以写入新的文件
                        // SaveModifiedBmp("modified_image.bmp", fileHeader, dibHeader, pixelData, width, height, rowSize);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("发生错误: " + ex.Message);
            }
        }

        private async Task HideInImageAsync(string sourceBmp, string outputPath, string secretFile, IProgress<ProgressReport> progress) {
            try {
                // 读取待隐写文件
                byte[] secretData = File.ReadAllBytes(secretFile);
                string extension = Path.GetExtension(secretFile).TrimStart('.');

                // 构建数据包
                byte[] dataPacket = BuildDataPacket(secretData, extension);

                // 读取BMP文件
                byte[] bmpBytes = File.ReadAllBytes(sourceBmp);

                // 嵌入数据（异步）
                await Task.Run(() => {
                    EmbedDataToPixelsWithProgress(bmpBytes, dataPacket, progress);
                });

                // 保存结果
                File.WriteAllBytes(outputPath, bmpBytes);
            } catch (Exception ex) {
                throw new Exception($"隐写失败：{ex.Message}");
            }
        }

        private byte[] BuildDataPacket(byte[] secretData, string extension) {
            // 处理扩展名
            byte[] extBytes = new byte[8];
            Encoding.ASCII.GetBytes(extension.PadRight(8, '\0').Substring(0, 8))
                         .CopyTo(extBytes, 0);

            // 构建数据包
            byte[] packet = new byte[HEADER_SIZE + secretData.Length];

            // 写入文件长度（小端序）
            BitConverter.GetBytes(secretData.Length).CopyTo(packet, 0);

            // 写入校验码
            MAGIC_BYTES.CopyTo(packet, 4);

            // 写入扩展名
            extBytes.CopyTo(packet, 12);

            // 写入文件内容
            secretData.CopyTo(packet, HEADER_SIZE);

            return packet;
        }

        private void EmbedDataToPixelsWithProgress(byte[] bmpBytes, byte[] dataPacket, IProgress<ProgressReport> progress) {
            // ...原有嵌入逻辑...
            // 转换为位流（每个字节的最低有效位）
            bool[] bits = new bool[dataPacket.Length * 8];
            for (int i = 0; i < dataPacket.Length; i++) {
                for (int j = 0; j < 8; j++) {
                    bits[i * 8 + j] = (dataPacket[i] & (1 << j)) != 0;
                }
            }

            // 获取像素数据位置
            int pixelOffset = BitConverter.ToInt32(bmpBytes, 10);
            int width = BitConverter.ToInt32(bmpBytes, 18);
            int height = BitConverter.ToInt32(bmpBytes, 22);
            int bpp = BitConverter.ToUInt16(bmpBytes, 28);
            int stride = (width * (bpp / 8) + 3) & ~3;

            // 检查容量
            if (bits.Length > maxHideFileSize * 8) {
                throw new InvalidOperationException("隐写数据超过容量限制");
            }

            int totalBits = bits.Length;
            int processedBits = 0;
            int bitIndex = 0;
            // 在嵌入循环中添加进度报告
            for (int y = 0; y < height; y++) {
                int rowStart = pixelOffset + y * stride;
                for (int x = 0; x < width * (bpp / 8); x++) {
                    // ...原有嵌入逻辑...
                    if (bitIndex >= bits.Length) return;

                    int pos = rowStart + x;
                    bmpBytes[pos] = (byte)((bmpBytes[pos] & 0xFE) | (bits[bitIndex] ? 1 : 0));
                    bitIndex++;
                    // 更新进度
                    if (bitIndex % 100 == 0) // 每100位更新一次
                    {
                        int percentage = (int)((double)processedBits / totalBits * 100);
                        progress?.Report(new ProgressReport {
                            Percentage = percentage,
                            StatusMessage = $"正在嵌入 {percentage}%"
                        });
                    }
                    processedBits++;
                }
            }
        }

        /*private void EmbedDataToPixels(byte[] bmpBytes, byte[] dataPacket) {
            // 转换为位流（每个字节的最低有效位）
            bool[] bits = new bool[dataPacket.Length * 8];
            for (int i = 0; i < dataPacket.Length; i++) {
                for (int j = 0; j < 8; j++) {
                    bits[i * 8 + j] = (dataPacket[i] & (1 << j)) != 0;
                }
            }

            // 获取像素数据位置
            int pixelOffset = BitConverter.ToInt32(bmpBytes, 10);
            int width = BitConverter.ToInt32(bmpBytes, 18);
            int height = BitConverter.ToInt32(bmpBytes, 22);
            int bpp = BitConverter.ToUInt16(bmpBytes, 28);
            int stride = (width * (bpp / 8) + 3) & ~3;

            // 检查容量
            if (bits.Length > maxHideFileSize) {
                throw new InvalidOperationException("隐写数据超过容量限制");
            }

            // 嵌入数据
            int bitIndex = 0;
            for (int y = 0; y < height; y++) {
                int rowStart = pixelOffset + y * stride;
                for (int x = 0; x < width * (bpp / 8); x++) {
                    if (bitIndex >= bits.Length) return;

                    int pos = rowStart + x;
                    bmpBytes[pos] = (byte)((bmpBytes[pos] & 0xFE) | (bits[bitIndex] ? 1 : 0));
                    bitIndex++;
                }
            }
        }*/

        private async Task ExtractDataAsync(string stegoBmp, string outputPath, IProgress<ProgressReport> progress) {
            try {
                byte[] bmpBytes = File.ReadAllBytes(stegoBmp);
                byte[] dataPacket = await Task.Run(() =>
                    ExtractFromPixelsWithProgress(bmpBytes, progress));
                if (!ValidatePacket(dataPacket)) {
                    MessageBox.Show("校验码错误，可能不是有效隐写文件");
                    return;
                }

                // 解析数据
                int dataLength = BitConverter.ToInt32(dataPacket, 0);
                string extension = Encoding.ASCII.GetString(dataPacket, 12, 8).TrimEnd('\0');
                byte[] secretData = new byte[dataLength];
                Array.Copy(dataPacket, HEADER_SIZE, secretData, 0, dataLength);

                // 保存文件
                File.WriteAllBytes($"{outputPath}.{extension}", secretData);
                // ...原有提取逻辑...
            } catch (Exception ex) {
                throw new Exception($"提取失败：{ex.Message}");
            }
        }

        /*public void ExtractData(string stegoBmp, string outputPath) {
            try {
                byte[] bmpBytes = File.ReadAllBytes(stegoBmp);
        
                // 提取数据包
                byte[] dataPacket = ExtractFromPixels(bmpBytes);

                // 验证校验码
                if (!ValidatePacket(dataPacket)) {
                    MessageBox.Show("校验码错误，可能不是有效隐写文件");
                    return;
                }

                // 解析数据
                int dataLength = BitConverter.ToInt32(dataPacket, 0);
                string extension = Encoding.ASCII.GetString(dataPacket, 12, 8).TrimEnd('\0');
                byte[] secretData = new byte[dataLength];
                Array.Copy(dataPacket, HEADER_SIZE, secretData, 0, dataLength);

                // 保存文件
                File.WriteAllBytes($"{outputPath}.{extension}", secretData);
                MessageBox.Show("提取成功！");
            } catch (Exception ex) {
                MessageBox.Show($"提取失败：{ex.Message}");
            }
        }*/

        private byte[] ExtractFromPixelsWithProgress(byte[] bmpBytes, IProgress<ProgressReport> progress) {
            // ...原有提取逻辑...
            int pixelOffset = BitConverter.ToInt32(bmpBytes, 10);
            int width = BitConverter.ToInt32(bmpBytes, 18);
            int height = BitConverter.ToInt32(bmpBytes, 22);
            int bpp = BitConverter.ToUInt16(bmpBytes, 28);
            int stride = (width * (bpp / 8) + 3) & ~3;

            int totalBits = width * height * (bpp / 8);
            int processedBits = 0;

            List<bool> bits = new List<bool>();
            for (int y = 0; y < height; y++) {
                int rowStart = pixelOffset + y * stride;
                for (int x = 0; x < width * (bpp / 8); x++) {
                    // ...原有提取逻辑...
                    bits.Add((bmpBytes[rowStart + x] & 1) != 0);
                    // 更新进度
                    if (processedBits % 1000 == 0) // 每1000位更新一次
                    {
                        int percentage = (int)((double)processedBits / totalBits * 100);
                        progress?.Report(new ProgressReport {
                            Percentage = percentage,
                            StatusMessage = $"正在提取 {percentage}%"
                        });
                    }
                    processedBits++;
                }
            }
            // 转换为字节数组
            byte[] packet = new byte[bits.Count / 8];
            for (int i = 0; i < packet.Length; i++) {
                for (int j = 0; j < 8; j++) {
                    if (bits[i * 8 + j]) {
                        packet[i] |= (byte)(1 << j);
                    }
                }
            }
            return packet;
        }

        private byte[] ExtractFromPixels(byte[] bmpBytes) {
            int pixelOffset = BitConverter.ToInt32(bmpBytes, 10);
            int width = BitConverter.ToInt32(bmpBytes, 18);
            int height = BitConverter.ToInt32(bmpBytes, 22);
            int bpp = BitConverter.ToUInt16(bmpBytes, 28);
            int stride = (width * (bpp / 8) + 3) & ~3;

            // 提取所有LSB位
            List<bool> bits = new List<bool>();
            for (int y = 0; y < height; y++) {
                int rowStart = pixelOffset + y * stride;
                for (int x = 0; x < width * (bpp / 8); x++) {
                    bits.Add((bmpBytes[rowStart + x] & 1) != 0);
                }
            }

            // 转换为字节数组
            byte[] packet = new byte[bits.Count / 8];
            for (int i = 0; i < packet.Length; i++) {
                for (int j = 0; j < 8; j++) {
                    if (bits[i * 8 + j]) {
                        packet[i] |= (byte)(1 << j);
                    }
                }
            }
            return packet;
        }

        private bool ValidatePacket(byte[] packet) {
            byte[] extractedMagic = new byte[8];
            Array.Copy(packet, 4, extractedMagic, 0, 8);
            return extractedMagic.SequenceEqual(MAGIC_BYTES);
        }

        private async void startHide_Click(object sender, EventArgs e) {
            try {
                startHide.Enabled = false;
                var progress = new Progress<ProgressReport>(report => {
                    progressBar.Value = report.Percentage;
                    statusLabel.Text = report.StatusMessage;
                });

                string outputPath = Path.Combine(outputFile.SelectedPath,
                    Path.GetFileNameWithoutExtension(fromPath.Text) + "_hided.bmp");

                await HideInImageAsync(fromPath.Text, outputPath, hideOrExtractPath.Text, progress);

                // 完成后的处理
                progressBar.Value = 100;
                statusLabel.Text = "隐写完成！";
                outputBMPPreview = Image.FromFile(outputPath);
                outputBMP.Image = outputBMPPreview;
                MessageBox.Show("隐写完成！");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                startHide.Enabled = true;
            }
        }

        /*private void startHide_Click(object sender, EventArgs e) {
            string outputPath = Path.Combine(outputFile.SelectedPath,
        Path.GetFileNameWithoutExtension(fromPath.Text) + "_stego.bmp");

            HideInImage(fromPath.Text, outputPath, hideOrExtractPath.Text);

            // 预览结果
            outputBMPPreview = Image.FromFile(outputPath);
            outputBMP.Image = outputBMPPreview;
        }*/

        private async void startExtract_Click(object sender, EventArgs e) {
            try {
                startExtract.Enabled = false;
                var progress = new Progress<ProgressReport>(report => {
                    progressBar.Value = report.Percentage;
                    statusLabel.Text = report.StatusMessage;
                });

                string outputFile = Path.Combine(outputPath.Text,
                    Path.GetFileNameWithoutExtension(hideOrExtractPath.Text));

                await ExtractDataAsync(hideOrExtractPath.Text, outputFile, progress);

                // 完成后的处理
                progressBar.Value = 100;
                statusLabel.Text = "提取完成！";
                MessageBox.Show("提取完成！");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                startExtract.Enabled = true;
            }
        }

        /*private void startExtract_Click(object sender, EventArgs e) {
            string outputFile = Path.Combine(outputPath.Text,
        Path.GetFileNameWithoutExtension(hideOrExtractPath.Text));

            ExtractData(hideOrExtractPath.Text, outputFile);
        }*/
    }

    public class ProgressReport {
        public int Percentage { get; set; }
        public string? StatusMessage { get; set; }
    }
}