<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row mt-2">

                                            <div class="col-12">

                                                <asp:GridView ID="gv" runat="server" CssClass="table w-100" AutoGenerateColumns="false" EmptyDataText="No Hay Data en la Base de Datos.">

                                                    <Columns>

                                                        <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="Nombre" ItemStyle-Width="700">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="Direccion" ItemStyle-Width="700">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDireccion" runat="server" Text='<%# Eval("Direccion") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="Cedula" ItemStyle-Width="700">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCedula" runat="server" Text='<%# Eval("Cedula") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="Telefono" ItemStyle-Width="700">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Eval("Telefono") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="table-dark" HeaderText="Estatus" ItemStyle-Width="700">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEstatus" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="table-dark" ItemStyle-Width="700">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" runat="server" class="btn btn-secondary" Text="Editar" CommandArgument='<%# Eval("Cedula") %>' OnClick="Consult" />
                                                                <asp:Button ID="btndelet" runat="server" class="btn btn-danger" Text="Eliminar" CommandArgument='<%# Eval("Cedula") %>' OnClick="Delete" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>