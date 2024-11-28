using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartErc.PartRuleSeverities
{
    public class RuleSeverities
    {
        [JsonPropertyName("bus_definition_conflict")]
        public string BusDefinitionConflict { get; set; }

        [JsonPropertyName("bus_entry_needed")]
        public string BusEntryNeeded { get; set; }

        [JsonPropertyName("bus_label_syntax")]
        public string BusLabelSyntax { get; set; }

        [JsonPropertyName("bus_to_bus_conflict")]
        public string BusToBusConflict { get; set; }

        [JsonPropertyName("bus_to_net_conflict")]
        public string BusToNetConflict { get; set; }

        [JsonPropertyName("conflicting_netclasses")]
        public string ConflictingNetclasses { get; set; }

        [JsonPropertyName("different_unit_footprint")]
        public string DifferentUnitFootprint { get; set; }

        [JsonPropertyName("different_unit_net")]
        public string DifferentUnitNet { get; set; }

        [JsonPropertyName("duplicate_reference")]
        public string DuplicateReference { get; set; }

        [JsonPropertyName("duplicate_sheet_names")]
        public string DuplicateSheetNames { get; set; }

        [JsonPropertyName("endpoint_off_grid")]
        public string EndpointOffGrid { get; set; }

        [JsonPropertyName("extra_units")]
        public string ExtraUnits { get; set; }

        [JsonPropertyName("footprint_link_issues")]
        public string FootprintLinkIssues { get; set; }

        [JsonPropertyName("four_way_junction")]
        public string FourWayJunction { get; set; }

        [JsonPropertyName("global_label_dangling")]
        public string GlobalLabelDangling { get; set; }

        [JsonPropertyName("hier_label_mismatch")]
        public string HierLabelMismatch { get; set; }

        [JsonPropertyName("label_dangling")]
        public string LabelDangling { get; set; }

        [JsonPropertyName("label_multiple_wires")]
        public string LabelMultipleWires { get; set; }

        [JsonPropertyName("lib_symbol_issues")]
        public string LibSymbolIssues { get; set; }

        [JsonPropertyName("lib_symbol_mismatch")]
        public string LibSymbolMismatch { get; set; }

        [JsonPropertyName("missing_bidi_pin")]
        public string MissingBidiPin { get; set; }

        [JsonPropertyName("missing_input_pin")]
        public string MissingInputPin { get; set; }

        [JsonPropertyName("missing_power_pin")]
        public string MissingPowerPin { get; set; }

        [JsonPropertyName("missing_unit")]
        public string MissingUnit { get; set; }

        [JsonPropertyName("multiple_net_names")]
        public string MultipleNetNames { get; set; }

        [JsonPropertyName("net_not_bus_member")]
        public string NetNotBusMember { get; set; }

        [JsonPropertyName("no_connect_connected")]
        public string NoConnectConnected { get; set; }

        [JsonPropertyName("no_connect_dangling")]
        public string NoConnectDangling { get; set; }

        [JsonPropertyName("overlapping_rule_areas")]
        public string OverlappingRuleAreas { get; set; }

        [JsonPropertyName("pin_not_connected")]
        public string PinNotConnected { get; set; }

        [JsonPropertyName("pin_not_driven")]
        public string PinNotDriven { get; set; }

        [JsonPropertyName("pin_to_pin")]
        public string PinToPin { get; set; }

        [JsonPropertyName("power_pin_not_driven")]
        public string PowerPinNotDriven { get; set; }

        [JsonPropertyName("same_local_global_label")]
        public string SameLocalGlobalLabel { get; set; }

        [JsonPropertyName("similar_label_and_power")]
        public string SimilarLabelAndPower { get; set; }

        [JsonPropertyName("similar_labels")]
        public string SimilarLabels { get; set; }

        [JsonPropertyName("similar_power")]
        public string SimilarPower { get; set; }

        [JsonPropertyName("simulation_model_issue")]
        public string SimulationModelIssue { get; set; }

        [JsonPropertyName("single_global_label")]
        public string SingleGlobalLabel { get; set; }

        [JsonPropertyName("unannotated")]
        public string Unannotated { get; set; }

        [JsonPropertyName("unconnected_wire_endpoint")]
        public string UnconnectedWireEndpoint { get; set; }

        [JsonPropertyName("unit_value_mismatch")]
        public string UnitValueMismatch { get; set; }

        [JsonPropertyName("unresolved_variable")]
        public string UnresolvedVariable { get; set; }

        [JsonPropertyName("wire_dangling")]
        public string WireDangling { get; set; }
    }
}
