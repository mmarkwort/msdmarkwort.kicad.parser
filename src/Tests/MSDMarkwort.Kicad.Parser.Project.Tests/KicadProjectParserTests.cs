using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace MSDMarkwort.Kicad.Parser.Project.Tests
{
    public class KicadProjectParserTests
    {
        [SetUp]
        public void Setup()
        {
            /*
            var outFile = "";

            var cur = Directory.GetCurrentDirectory();

            var testProjects = Directory.GetFiles("../../../../TestProjects/", "*.kicad_pro", SearchOption.AllDirectories);

            foreach (var file in testProjects.Concat(testProjects))
            {
                outFile += $"[TestCase(\"{file.Replace('\\', '/')}\")]\n";
            }
            */
        }

        [TestCase("../../../../TestProjects/complex_hierarchy/complex_hierarchy.kicad_pro")]
        [TestCase("../../../../TestProjects/custom_pads_test/custom_pads_test.kicad_pro")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp.kicad_pro")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp_v2.kicad_pro")]
        [TestCase("../../../../TestProjects/flat_hierarchy/flat_hierarchy.kicad_pro")]
        [TestCase("../../../../TestProjects/interf_u/interf_u.kicad_pro")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/kit-dev-coldfire-xilinx_5213.kicad_pro")]
        [TestCase("../../../../TestProjects/microwave/microwave.kicad_pro")]
        [TestCase("../../../../TestProjects/multichannel/multichannel_mixer.kicad_pro")]
        [TestCase("../../../../TestProjects/pic_programmer/pic_programmer.kicad_pro")]
        [TestCase("../../../../TestProjects/sonde xilinx/sonde xilinx.kicad_pro")]
        [TestCase("../../../../TestProjects/stickhub/StickHub.kicad_pro")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/test_pads_inside_pads.kicad_pro")]
        [TestCase("../../../../TestProjects/test_xil_95108/carte_test.kicad_pro")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-demo.kicad_pro")]
        [TestCase("../../../../TestProjects/video/video.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/analog-multiplier/a-multi.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/class-d/Class-D.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/gain_control/mult_vca810.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/generic_models/generic_opamp_bip.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/ibis/ibis.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/laser_driver.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/pspice/pspice.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/q17/Q17ng.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/rectifier/rectifier.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sallen_key.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/up-down-counter/up-down-c.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/v_i_sources.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/smps-com.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/buck_conv/buck_conv.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/hv_converter/hv_converter.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/LM317_power_supply/power_supply.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/royer/royer1.kicad_pro")]
        [TestCase("../../../../TestProjects/complex_hierarchy/complex_hierarchy.kicad_pro")]
        [TestCase("../../../../TestProjects/custom_pads_test/custom_pads_test.kicad_pro")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp.kicad_pro")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp_v2.kicad_pro")]
        [TestCase("../../../../TestProjects/flat_hierarchy/flat_hierarchy.kicad_pro")]
        [TestCase("../../../../TestProjects/interf_u/interf_u.kicad_pro")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/kit-dev-coldfire-xilinx_5213.kicad_pro")]
        [TestCase("../../../../TestProjects/microwave/microwave.kicad_pro")]
        [TestCase("../../../../TestProjects/multichannel/multichannel_mixer.kicad_pro")]
        [TestCase("../../../../TestProjects/pic_programmer/pic_programmer.kicad_pro")]
        [TestCase("../../../../TestProjects/sonde xilinx/sonde xilinx.kicad_pro")]
        [TestCase("../../../../TestProjects/stickhub/StickHub.kicad_pro")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/test_pads_inside_pads.kicad_pro")]
        [TestCase("../../../../TestProjects/test_xil_95108/carte_test.kicad_pro")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-demo.kicad_pro")]
        [TestCase("../../../../TestProjects/video/video.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/analog-multiplier/a-multi.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/class-d/Class-D.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/gain_control/mult_vca810.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/generic_models/generic_opamp_bip.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/ibis/ibis.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/laser_driver.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/pspice/pspice.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/q17/Q17ng.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/rectifier/rectifier.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sallen_key.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/up-down-counter/up-down-c.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/v_i_sources.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/smps-com.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/buck_conv/buck_conv.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/hv_converter/hv_converter.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/LM317_power_supply/power_supply.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/royer/royer1.kicad_pro")]
        public async Task ParseTest(string inputProject)
        {
            await using var inputProjectStream = File.OpenRead(inputProject);

            var parser = new KicadProjectParser();
            var parserResult = await parser.ParseAsync(inputProjectStream, JsonUnmappedMemberHandling.Disallow);

            Assert.That(parserResult.Success, Is.EqualTo(true));
        }

        [Test]
        public async Task ParseAsync_InvalidJsonStream_ReturnsFailure()
        {
            var invalidJson = "{ invalid json content";
            await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(invalidJson));
            
            var parser = new KicadProjectParser();
            var result = await parser.ParseAsync(stream);
            
            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Exception, Is.InstanceOf<JsonException>());
            Assert.That(result.Result, Is.Null);
        }

        [Test]
        public async Task ParseAsync_EmptyStream_ReturnsFailure()
        {
            await using var stream = new MemoryStream();
            
            var parser = new KicadProjectParser();
            var result = await parser.ParseAsync(stream);
            
            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Result, Is.Null);
        }

        [Test]
        public async Task ParseAsync_NullStream_ReturnsFailure()
        {
            var parser = new KicadProjectParser();
            var result = await parser.ParseAsync((Stream)null);
            
            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Exception, Is.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public async Task ParseAsync_DisallowUnmappedMembers_WithUnknownProperty_ReturnsFailure()
        {
            var jsonWithUnknownProperty = @"{
                ""board"": {
                    ""unknown_property"": ""value""
                }
            }";
            await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonWithUnknownProperty));
            
            var parser = new KicadProjectParser();
            var result = await parser.ParseAsync(stream, JsonUnmappedMemberHandling.Disallow);
            
            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Exception, Is.InstanceOf<JsonException>());
        }

        [Test]
        public async Task ParseAsync_SkipUnmappedMembers_WithUnknownProperty_ReturnsSuccess()
        {
            var jsonWithUnknownProperty = @"{
                ""board"": {
                    ""unknown_property"": ""value""
                }
            }";
            await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonWithUnknownProperty));
            
            var parser = new KicadProjectParser();
            var result = await parser.ParseAsync(stream, JsonUnmappedMemberHandling.Skip);
            
            Assert.That(result.Success, Is.True);
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Error, Is.Null);
        }

        [Test]
        public async Task ParseAsync_MinimalValidProject_ReturnsSuccess()
        {
            var minimalJson = @"{}";
            await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(minimalJson));
            
            var parser = new KicadProjectParser();
            var result = await parser.ParseAsync(stream);
            
            Assert.That(result.Success, Is.True);
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Error, Is.Null);
            Assert.That(result.Warnings, Is.Not.Null);
            Assert.That(result.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void ParseAsync_FilePath_NonExistentFile_ThrowsException()
        {
            var parser = new KicadProjectParser();
            
            Assert.ThrowsAsync<FileNotFoundException>(async () =>
                await parser.ParseAsync("nonexistent_file.kicad_pro"));
        }

        [Test]
        public void ParseAsync_NullFilePath_ThrowsException()
        {
            var parser = new KicadProjectParser();
            
            Assert.ThrowsAsync<ArgumentNullException>(async () => 
                await parser.ParseAsync((string)null));
        }

        [Test]
        public async Task ParseAsync_LargeValidProject_ReturnsSuccess()
        {
            var largeJson = @"{
                ""board"": {
                    ""design_settings"": {
                        ""defaults"": {
                            ""board_outline_line_width"": 0.1,
                            ""copper_line_width"": 0.2
                        }
                    }
                },
                ""cvpcb"": {
                    ""equivalence_files"": []
                },
                ""erc"": {
                    ""erc_exclusions"": []
                },
                ""libraries"": {
                    ""pinned_footprint_libs"": [],
                    ""pinned_symbol_libs"": []
                },
                ""meta"": {
                    ""version"": 1
                },
                ""net_settings"": {
                    ""classes"": [
                        {
                            ""bus_width"": 12,
                            ""clearance"": 0.2,
                            ""diff_pair_gap"": 0.25,
                            ""diff_pair_via_gap"": 0.25,
                            ""diff_pair_width"": 0.2,
                            ""line_width"": 0.25,
                            ""microvia_diameter"": 0.3,
                            ""microvia_drill"": 0.1,
                            ""name"": ""Default"",
                            ""pcb_color"": ""rgba(0, 0, 0, 0.000)"",
                            ""schematic_color"": ""rgba(0, 0, 0, 0.000)"",
                            ""track_width"": 0.25,
                            ""via_diameter"": 0.8,
                            ""via_drill"": 0.4,
                            ""wire_width"": 6
                        }
                    ],
                    ""meta"": {
                        ""version"": 3
                    }
                },
                ""pcbnew"": {
                    ""last_paths"": {
                        ""gencad"": """",
                        ""idf"": """",
                        ""netlist"": """",
                        ""specctra_dsn"": """",
                        ""step"": """",
                        ""vrml"": """"
                    },
                    ""page_layout_descr_file"": """"
                },
                ""schematic"": {
                    ""annotate_start_num"": 0,
                    ""drawing"": {
                        ""dashed_lines_dash_length_ratio"": 12.0,
                        ""dashed_lines_gap_length_ratio"": 3.0,
                        ""default_line_thickness"": 6.0,
                        ""default_text_size"": 1.27,
                        ""field_names"": [],
                        ""intersheets_ref_own_page"": false,
                        ""intersheets_ref_prefix"": """",
                        ""intersheets_ref_short"": false,
                        ""intersheets_ref_show"": false,
                        ""intersheets_ref_suffix"": """",
                        ""junction_size_choice"": 3,
                        ""label_size_ratio"": 0.375,
                        ""no_connect_dash_length"": 12.0,
                        ""no_connect_dash_gap"": 3.0,
                        ""pin_symbol_size"": 25.0,
                        ""text_offset_ratio"": 0.15
                    },
                    ""legacy_lib_dir"": """",
                    ""legacy_lib_list"": []
                }
            }";
            await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(largeJson));
            
            var parser = new KicadProjectParser();
            var result = await parser.ParseAsync(stream);
            
            Assert.That(result.Success, Is.True);
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Error, Is.Null);
        }
    }
}
