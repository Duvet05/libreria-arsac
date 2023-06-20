/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.producto.model;
/**
 *
 * @author User
 */
public class Producto {
    private int idProducto;
    private String nombre;
    private double precioPorMenor;
    private double precioPorMayor;
    private boolean activo;
    private byte[] foto;
    private Marca marca;
    private Categoria categoria;
    private Promocion promocion;
    
    public int getIdProducto() {
        return idProducto;
    }

    public void setIdProducto(int idProducto) {
        this.idProducto = idProducto;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public double getPrecioPorMenor() {
        return precioPorMenor;
    }

    public void setPrecioPorMenor(double precioPorMenor) {
        this.precioPorMenor = precioPorMenor;
    }

    public double getPrecioPorMayor() {
        return precioPorMayor;
    }

    public void setPrecioPorMayor(double precioPorMayor) {
        this.precioPorMayor = precioPorMayor;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public Marca getMarca() {
        return marca;
    }

    public void setMarca(Marca marca) {
        this.marca = marca;
    }

    public Categoria getCategoria() {
        return categoria;
    }

    public void setCategoria(Categoria categoria) {
        this.categoria = categoria;
    }

    public Promocion getPromocion() {
        return promocion;
    }

    public void setPromocion(Promocion promocion) {
        this.promocion = promocion;
    }
    public byte[] getFoto() {
        return foto;
    }

    public void setFoto(byte[] foto) {
        this.foto = foto;
    }
    
    public Producto() {
    }
}
